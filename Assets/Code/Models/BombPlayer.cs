using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlayer : Bomb
{
    // == VAR & CONST ========================================================================================================

    public const int BOMB_EXPLOSION_TIME = 2000;
    public const int BOMB_MOVE_DELAY = 150;
    public const int BOMB_ANIM_DELAY = 150;
    private float _bombUseTime = 0;
    private float _bombLastMovement = 0;
    private int _bombAnimationCount = 2;
    private float _bombDetonationAnimationTime = 0;
    private int _bombDetonationAnimationCount = 1;
    
    private bool _isFalling = false;
    private bool _explosionPlaced = false;

    // == METHODS ============================================================================================================

    public BombPlayer(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/BOMB2");
        this._bombUseTime = Time.time * 1000;
        this._bombLastMovement = Time.time * 1000;
    }

    public override void update()
    {
        base.update();

        if (this._detonate == false)
        {
            // BOMB DETONATION BY TIME
            if ((Time.time * 1000) - this._bombUseTime > BOMB_EXPLOSION_TIME)
            {
                this._detonate = true;
                this._bombDetonationAnimationTime = Time.time;
            }
            else
            {
                if ((Time.time * 1000) - this._bombLastMovement > BOMB_MOVE_DELAY)
                {
                    try
                    {
                        Vector2 nextPosVector = new Vector2(0, 1);
                        Tile nextTile = this._parent.getTileOnPosition(this._position + nextPosVector);

                        if (nextTile == null || nextTile is Empty)
                        {
                            this._isFalling = true;
                            this._parent.setTilePosition(this, this._position + nextPosVector);
                        }
                        else
                        {
                            if (this._isFalling)
                            {
                                this._detonate = true;
                                this._bombDetonationAnimationTime = Time.time;
                            }
                        }
                    }
                    catch( System.IndexOutOfRangeException e )
                    {
                        this._detonate = true;
                    }

                    // BOMB ANIMATION

                    if( this._bombAnimationCount > 3 )
                    {
                        this._bombAnimationCount = 2;
                    }

                    this._sprite = Resources.Load<Sprite>("Sprites/BOMB" + this._bombAnimationCount);
                    this._bombAnimationCount++;

                    this._bombLastMovement = Time.time * 1000;
                }
            }
        }
        else
        {
            if (!this._explosionPlaced)
            {
                this._explosionPlaced = true;

                for (int countX = -1; countX <= 1; countX++)
                {
                    for (int countY = -1; countY <= 1; countY++)
                    {
                        try
                        {
                            Tile tileInPos = this._parent.getTileOnPosition(this._position + new Vector2(countX, countY));

                            if (tileInPos != null && !(tileInPos is Empty))
                            {
                                if (!(tileInPos is Explosion))
                                {
                                    if (tileInPos is Player)
                                    {
                                        ((Player)tileInPos).kill(DeathType.MELTED);
                                    }
                                    else if (tileInPos is Bomb)
                                    {
                                        ((Bomb)tileInPos).detonate();
                                    }
                                    else
                                    {
                                        this._parent.deleteDynamicTile(tileInPos);
                                        this._parent.createTile("Explosion", tileInPos.position);
                                    }
                                }
                            }
                            else
                            {
                                this._parent.createTile("Explosion", this._position + new Vector2(countX, countY));
                            }
                        }
                        catch( System.IndexOutOfRangeException e )
                        {
                            continue;
                        }
                    }
                }
            }

            if ( (Time.time * 1000) - this._bombDetonationAnimationTime > BOMB_ANIM_DELAY)
            {
                if( this._bombDetonationAnimationCount <= 4 )
                {
                    this._sprite = Resources.Load<Sprite>("Sprites/EXPLODE" + this._bombDetonationAnimationCount);
                    this._bombDetonationAnimationCount++;
                }
                else
                {
                    this._parent.createTile("Empty", this._position);
                    this._parent.deleteDynamicTile(this);
                }

                this._bombDetonationAnimationTime = Time.time * 1000;
            }
        }
    }

    // == EVENTS =============================================================================================================
}

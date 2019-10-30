using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : Tile
{
    // == VAR & CONST ========================================================================================================

    protected const int MOVEMENT_DELAY = 150;
    protected float lastMovement = 0;
    protected bool _isFalling = false;

    // == METHODS ============================================================================================================

    public Heavy(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
    }

    public override void update()
    {
        base.update();

        if ((Time.time * 1000) - lastMovement > MOVEMENT_DELAY)
        {
            Tile underTile = this._parent.getTileOnPosition( this._position + new Vector2(0, 1) );

            if(underTile is Empty)
            {
                this._parent.setTilePosition(this, this._position + new Vector2(0, 1));
                this._isFalling = true;
            }
            else
            {
                if(underTile is Player && this._isFalling == true)
                {
                    // DEATH

                    this._parent.setTilePosition(this, this._position + new Vector2(0, 1));
                    ((Player)underTile).kill(DeathType.CRUSH);

                }
                else if (underTile is Enemy && this._isFalling == true)
                {
                    this._parent.deteleTileFromMap(position);
                    this._parent.deleteDynamicTile(this);

                    this._parent.deteleTileFromMap(underTile.position);
                    this._parent.deleteDynamicTile(underTile);

                    for( int countX = (int) underTile.position.x - 1; countX <= underTile.position.x + 1; countX++ )
                    {
                        for (int countY = (int) underTile.position.y - 1; countY <= underTile.position.y + 1; countY++)
                        {
                            Tile currentTile = this._parent.getTileOnPosition( new Vector2(countX, countY) );

                            if(currentTile == null || currentTile is Dirt || currentTile is Empty)
                            {
                                this._parent.createTile("Ruby", new Vector2(countX, countY));
                            }
                        }
                    }
                }
                else if( underTile is Bomb )
                {
                    ((Bomb)underTile).detonate();
                }
                else
                {
                    // CHECKING FOR ROLLING SIDE

                    if( this._currentRollSide == RollSide.LEFT )
                    {
                        Tile leftTile = this._parent.getTileOnPosition( this._position + new Vector2(-1, 0) );

                        if( leftTile is Empty )
                        {
                            Tile bottomLeftTile = this._parent.getTileOnPosition(this._position + new Vector2(-1, 1));

                            if (bottomLeftTile is Empty)
                            {
                                this._parent.setTilePosition(this, this._position + new Vector2(-1, 0) );
                            }
                            else
                            {
                                this._isFalling = false;
                            }
                        }
                        else
                        {
                            this._isFalling = false;
                        }
                    }
                    else if( this._currentRollSide == RollSide.RIGHT )
                    {
                        Tile rightTile = this._parent.getTileOnPosition(this._position + new Vector2(1, 0));

                        if (rightTile is Empty)
                        {
                            Tile bottomRightTile = this._parent.getTileOnPosition(this._position + new Vector2(1, 1));

                            if (bottomRightTile is Empty)
                            {
                                this._parent.setTilePosition(this, this._position + new Vector2(1, 0));
                            }
                            else
                            {
                                this._isFalling = false;
                            }
                        }
                        else
                        {
                            this._isFalling = false;
                        }
                    }
                    else
                    {
                        this._isFalling = false;
                    }
                }
            }

            lastMovement = Time.time * 1000;
        }
    }

    // == EVENTS =============================================================================================================

    // == GETTERS AND SETTERS  ===============================================================================================

    public RollSide rollSide
    {
        get { return this._currentRollSide; }
    }
}

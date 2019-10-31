using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tile
{
    // == VAR & CONST ========================================================================================================

    protected const int ANIM_DELAY = 70;
    protected const int MOVEMENT_DELAY = 150;
    protected const int HEAVY_MOVE_EFFORT = 3;
    protected bool _delayExplosion = true;
    protected float _deathTime = 0;
    protected float _lastAnim = 0;
    protected float _lastMovement = 0;
    protected int _moveHeavyEffortCount = 0;
    protected int _currentAnimSeq = 0;
    protected Sprite[] _animSpriteSeq;
    protected ElementLifeStatus _elementLifeStatus = ElementLifeStatus.ALIVE;
    protected int _explodeCount = 1;

    // == METHODS ============================================================================================================

    public Player( ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
        this._faceDirection = TileFaceDirection.RIGHT;

        this._currentAnimSeq = 0;
        this._animSpriteSeq = new Sprite[]
        {
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK01" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK02" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK03" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK04" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK05" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK06" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK07" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK08" ),
            this._sprite = Resources.Load<Sprite>( "Sprites/WALK09" ),
        };

        this._sprite = this._animSpriteSeq[this._currentAnimSeq];
    }

    protected void updateAnimation()
    {
        if ((Time.time * 1000) - this._lastAnim > ANIM_DELAY)
        {
            this._currentAnimSeq++;

            if (this._currentAnimSeq > this._animSpriteSeq.Length - 1)
            {
                this._currentAnimSeq = 0;
            }

            this._sprite = this._animSpriteSeq[this._currentAnimSeq];
            this._lastAnim = Time.time * 1000;
        }
    }

    public void kill(DeathType type)
    {
        if (type == DeathType.CRUSH)
        {
            this._parent.playSoundFX(SoundFX.SLOP);
            this._elementLifeStatus = ElementLifeStatus.DEATH_CRUSH;
        }
        else if (type == DeathType.GEMCRUSH)
        {
            this._parent.playSoundFX(SoundFX.BREAK);
            this._elementLifeStatus = ElementLifeStatus.DEATH_CRUSH;
        }
        else if (type == DeathType.MELTED)
        {
            this._parent.playSoundFX(SoundFX.LAVA);
            this._elementLifeStatus = ElementLifeStatus.DEATH_MELT;
        }
        else if (type == DeathType.EATEN)
        {
            this._parent.playSoundFX(SoundFX.SLURP);
            this._elementLifeStatus = ElementLifeStatus.DEATH_EATEN;
        }
        else if (type == DeathType.EXPLODED)
        {
            this._elementLifeStatus = ElementLifeStatus.DEATH_MELT;
        }
    }

    public override void update()
    {
        base.update();

        if (this._elementLifeStatus == ElementLifeStatus.ALIVE)
        {
            bool move = false;
            Vector2 nextPos = Vector2.zero;
            TileMovementDirection currentMovement = TileMovementDirection.NO_MOVEMENT;

            // == GAME CONTROLS

            PlayerControl pControl = PlayerControl.NONE;

            // CHECK MOVEMENT: PC

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pControl = PlayerControl.LEFT;
                this.updateAnimation();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                pControl = PlayerControl.RIGHT;
                this.updateAnimation();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                pControl = PlayerControl.UP;
                this.updateAnimation();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                pControl = PlayerControl.DOWN;
                this.updateAnimation();
            }

            // DETECTED PLAYER CONTROLS

            switch(pControl)
            {
                case PlayerControl.LEFT:

                    if ((Time.time * 1000) - this._lastMovement > MOVEMENT_DELAY)
                    {
                        move = true;
                        nextPos = this._position + new Vector2(-1, 0);
                        _lastMovement = Time.time * 1000;
                        this._faceDirection = TileFaceDirection.LEFT;
                        currentMovement = TileMovementDirection.LEFT;
                    }

                    break;

                case PlayerControl.RIGHT:

                    if ((Time.time * 1000) - this._lastMovement > MOVEMENT_DELAY)
                    {
                        move = true;
                        nextPos = this._position + new Vector2(1, 0);
                        _lastMovement = Time.time * 1000;
                        this._faceDirection = TileFaceDirection.RIGHT;
                        currentMovement = TileMovementDirection.RIGHT;
                    }

                    break;

                case PlayerControl.UP:

                    if ((Time.time * 1000) - this._lastMovement > MOVEMENT_DELAY)
                    {
                        move = true;
                        nextPos = this._position + new Vector2(0, -1);
                        _lastMovement = Time.time * 1000;
                        currentMovement = TileMovementDirection.UP;
                    }

                    break;

                case PlayerControl.DOWN:

                    if ((Time.time * 1000) - this._lastMovement > MOVEMENT_DELAY)
                    {
                        move = true;
                        nextPos = this._position + new Vector2(0, 1);
                        _lastMovement = Time.time * 1000;
                        currentMovement = TileMovementDirection.DOWN;
                    }

                    break;

                case PlayerControl.BOMB:

                    pControl = PlayerControl.BOMB;
                    
                    break;
            }

            // UPDATE MOVEMENT

            if (move)
            {
                bool outOfBounds = false;
                Tile colisionTile = null;

                try
                {
                    colisionTile = this._parent.getTileOnPosition(nextPos);
                }
                catch( System.IndexOutOfRangeException e )
                {
                    outOfBounds = true;
                }

                if (!outOfBounds && colisionTile != null)
                {
                    if ( !(colisionTile is Wall) )
                    {
                        if (colisionTile is Exit)
                        {
                            if (((Exit)colisionTile).open)
                            {
                                this._parent.setTilePosition(this, nextPos);

                                // LEVEL FINISHED
                                this._parent.completeLevel();
                            }

                            this._moveHeavyEffortCount = 0;
                        }
                        else if (colisionTile is Dirt)
                        {
                            this._parent.playSoundFX(SoundFX.DIRT);
                            this._parent.setTilePosition(this, nextPos);
                        }
                        else if (colisionTile is Collectible)
                        {
                            if (colisionTile is Gem)
                            {
                                SessionData.score += ((Gem)colisionTile).score;
                                this._parent.playSoundFX(SoundFX.GEM);
                                this._parent.collectGem();
                                this._parent.setTilePosition(this, nextPos);
                            }
                            else if (colisionTile is Score)
                            {
                                SessionData.score += ((Score)colisionTile).score;
                                this._parent.playSoundFX(SoundFX.GEM);
                                this._parent.setTilePosition(this, nextPos);
                            }
                            else if (colisionTile is Clock)
                            {
                                this._parent.collectClock();
                                this._parent.playSoundFX(SoundFX.CLOCK);
                                this._parent.setTilePosition(this, nextPos);
                            }
                            else if (colisionTile is Power)
                            {
                                SessionData.lives++;
                                this._parent.playSoundFX(SoundFX.NEWLIFE);
                                this._parent.setTilePosition(this, nextPos);
                            }

                            this._parent.deleteDynamicTile(colisionTile);

                            this._moveHeavyEffortCount = 0;
                        }
                        else if (colisionTile is Heavy)
                        {
                            if (this._moveHeavyEffortCount > HEAVY_MOVE_EFFORT)
                            {
                                // MOVE THE HEAVY OBJECT
                                if (currentMovement == TileMovementDirection.RIGHT)
                                {
                                    Tile moveSpace = this._parent.getTileOnPosition(colisionTile.position + new Vector2(1, 0));

                                    if (moveSpace is Empty)
                                    {
                                        this._parent.playSoundFX(SoundFX.GRUNT);
                                        this._parent.setTilePosition(colisionTile, colisionTile.position + new Vector2(1, 0));
                                        this._parent.setTilePosition(this, this.position + new Vector2(1, 0));
                                    }
                                }
                                else if (currentMovement == TileMovementDirection.LEFT)
                                {
                                    Tile moveSpace = this._parent.getTileOnPosition(colisionTile.position + new Vector2(-1, 0));

                                    if (moveSpace is Empty)
                                    {
                                        this._parent.playSoundFX(SoundFX.GRUNT);
                                        this._parent.setTilePosition(colisionTile, colisionTile.position + new Vector2(-1, 0));
                                        this._parent.setTilePosition(this, this.position + new Vector2(-1, 0));
                                    }
                                }

                                // RESET THE COUNTER 
                                this._moveHeavyEffortCount = 0;
                            }

                            this._moveHeavyEffortCount++;
                        }
                        else if( colisionTile is Bomb )
                        {
                            Bomb bomb = (Bomb)colisionTile;

                            if(bomb.isCollectible)
                            {
                                this._parent.collectBomb();
                                this._parent.deleteDynamicTile(bomb);
                                this._parent.setTilePosition(this, nextPos);
                            }
                        }
                        else
                        {
                            this._moveHeavyEffortCount = 0;
                            this._parent.setTilePosition(this, nextPos);
                        }
                    }
                }
            }


            if ( pControl == PlayerControl.BOMB )
            {
                // BOMB 
                if(this._parent.levelBombs > 0)
                {
                    Vector2 frontVector = Vector2.zero;

                    switch( this._faceDirection )
                    {
                        case TileFaceDirection.LEFT:
                            frontVector = new Vector2(-1, 0);
                            break;

                        case TileFaceDirection.RIGHT:
                            frontVector = new Vector2(1, 0);
                            break;
                    }

                    Tile frontTile = this._parent.getTileOnPosition(this._position + frontVector);

                    if(frontTile == null || frontTile is Empty)
                    {
                        this._parent.createTile("BombPlayer", this._position + frontVector);
                        this._parent.useBomb();
                    }
                }
            }
        }
        else if (this._elementLifeStatus == ElementLifeStatus.DEATH_CRUSH)
        {
            this._elementLifeStatus = ElementLifeStatus.DEATH;
            this._deathTime = Time.time * 1000;
        }
        else if (this._elementLifeStatus == ElementLifeStatus.DEATH_MELT)
        {
            if ((Time.time * 1000) - this._lastMovement > MOVEMENT_DELAY)
            {
                if (this._explodeCount < 4)
                {
                    this._sprite = Resources.Load<Sprite>("Sprites/EXPLODE" + this._explodeCount);
                    this._explodeCount++;
                }
                else
                {
                    if (!this._delayExplosion)
                    {
                        this._elementLifeStatus = ElementLifeStatus.DEATH;
                        this._deathTime = Time.time * 1000;
                    }
                    else
                    {
                        this._sprite = Resources.Load<Sprite>("Sprites/SPACE");
                        this._delayExplosion = false;
                    }
                }

                this._lastMovement = Time.time * 1000;
            }
        }
        else if (this._elementLifeStatus == ElementLifeStatus.DEATH_EATEN)
        {
            this._elementLifeStatus = ElementLifeStatus.DEATH;
            this._deathTime = Time.time * 1000;
        }
        else if (this._elementLifeStatus == ElementLifeStatus.DEATH)
        {
            this._parent.playerDied();
        }
    }

    // == EVENTS =============================================================================================================

    // == GETTERS & SETTERS ==================================================================================================

    public ElementLifeStatus elementLifeStatus
    {
        get { return this._elementLifeStatus; }
    }
}

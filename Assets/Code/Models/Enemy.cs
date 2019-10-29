using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tile
{
    // == VAR & CONST ========================================================================================================

    protected const int MOVEMENT_DELAY = 150;
    protected float _lastMovement = 0;
    protected bool _disoriented = false;

    // == METHODS ============================================================================================================

    public Enemy(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
        this._faceDirection = TileFaceDirection.DOWN;
    }

    public override void update()
    {
        base.update();

        if ((Time.time * 1000) - this._lastMovement > MOVEMENT_DELAY)
        {
            bool playerCatch = false;

            // SCAN THE POSITION LOOKING FOR THE PLAYER

            Tile leftTile = this._parent.getTileOnPosition( this._position + new Vector2(-1, 0) );
            Tile rightTile = this._parent.getTileOnPosition( this._position + new Vector2(1, 0) );
            Tile upTile = this._parent.getTileOnPosition( this._position + new Vector2(0, -1) );
            Tile downTile = this._parent.getTileOnPosition( this._position + new Vector2(0, 1) );
            Tile playerTile = null;

            if(leftTile is Player)
            {
                playerTile = leftTile;
            }
            else if(rightTile is Player)
            {
                playerTile = rightTile;
            }
            else if (upTile is Player)
            {
                playerTile = upTile;
            }
            else if (downTile is Player)
            {
                playerTile = downTile;
            }

            if (playerTile != null)
            {
                // PLAYER DEATH

                ( (Player) playerTile).kill( DeathType.CRUSH );
                this._parent.setTilePosition(this, playerTile.position);

                playerCatch = true;
            }

            // SCAN THE POSITION FOR THE PATH

            if ( !playerCatch && this._parent.isPlayerAlive() )
            {
                Vector2 frontVectorPos = Vector2.zero;
                Vector2 bottomVectorPos = Vector2.zero;

                switch ( this._faceDirection )
                {
                    case TileFaceDirection.DOWN:
                        frontVectorPos = new Vector2(-1, 0);
                        bottomVectorPos = new Vector2(0, 1);
                        break;

                    case TileFaceDirection.LEFT:
                        frontVectorPos = new Vector2(0, -1);
                        bottomVectorPos = new Vector2(-1, 0);
                        break;

                    case TileFaceDirection.UP:
                        frontVectorPos = new Vector2(1, 0);
                        bottomVectorPos = new Vector2(0, -1);
                        break;

                    case TileFaceDirection.RIGHT:
                        frontVectorPos = new Vector2(0, 1);
                        bottomVectorPos = new Vector2(1, 0);
                        break;
                }

                Tile bottomTile = this._parent.getTileOnPosition(this._position + bottomVectorPos);

                if( bottomTile != null && !(bottomTile is Empty) )
                {
                    this._disoriented = false;

                    Tile frontTile = this._parent.getTileOnPosition(this._position + frontVectorPos);

                    if( frontTile == null || frontTile is Empty )
                    {
                        this._parent.setTilePosition(this, this._position + frontVectorPos);
                    }
                    else
                    {
                        switch (this._faceDirection)
                        {
                            case TileFaceDirection.DOWN:
                                this._faceDirection = TileFaceDirection.LEFT;
                                break;

                            case TileFaceDirection.LEFT:
                                this._faceDirection = TileFaceDirection.UP;
                                break;

                            case TileFaceDirection.UP:
                                this._faceDirection = TileFaceDirection.RIGHT;
                                break;

                            case TileFaceDirection.RIGHT:
                                this._faceDirection = TileFaceDirection.DOWN;
                                break;
                        }
                    }
                }
                else
                {
                    // ENENY KEEP MOVES AROUND ITSELF

                    this._disoriented = true;
                    this._parent.setTilePosition(this, this._position + bottomVectorPos);

                    switch( this._faceDirection )
                    {
                        case TileFaceDirection.DOWN:
                            this._faceDirection = TileFaceDirection.RIGHT;
                            break;

                        case TileFaceDirection.RIGHT:
                            this._faceDirection = TileFaceDirection.UP;
                            break;

                        case TileFaceDirection.UP:
                            this._faceDirection = TileFaceDirection.LEFT;
                            break;

                        case TileFaceDirection.LEFT:
                            this._faceDirection = TileFaceDirection.DOWN;
                            break;
                    }
                }
                
            }

            this._lastMovement = Time.time * 1000;
        }
    }

    // == EVENTS =============================================================================================================

    // == GETTERS & SETTERS ==================================================================================================

    public bool disoriented
    {
        get { return this._disoriented; }
    }
}

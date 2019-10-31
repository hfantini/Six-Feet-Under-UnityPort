using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tile
{
    // == VAR & CONST ========================================================================================================

    protected const int MOVEMENT_DELAY = 150;
    protected float _lastMovement = 0;
    protected bool _disoriented = false;
    bool playerCatch = false;

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
            
            // SCAN THE POSITION LOOKING FOR THE PLAYER

            for( int countX = 0; countX < 4; countX++ )
            {
                Vector2 scanPositionVector = Vector2.zero;

                switch(countX)
                {
                    case 0:
                        scanPositionVector = new Vector2(0, -1);
                        break;

                    case 1:
                        scanPositionVector = new Vector2(1, 0);
                        break;

                    case 2:
                        scanPositionVector = new Vector2(0, 1);
                        break;

                    case 3:
                        scanPositionVector = new Vector2(-1, 0);
                        break;
                }

                Tile currentTile = this._parent.getTileOnPosition( this._position + scanPositionVector);

                if( currentTile != null && currentTile is Player )
                {
                    // PLAYER DEATH

                    ( (Player)currentTile).kill(DeathType.EATEN);
                    this._parent.setTilePosition(this, currentTile.position);

                    playerCatch = true;
                }
            }

            // SCAN THE POSITION FOR THE PATH

            if ( !playerCatch )
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

                if(bottomTile == null || !(bottomTile is Empty) )
                {
                    this._disoriented = false;

                    Tile frontTile = this._parent.getTileOnPosition(this._position + frontVectorPos);

                    if( frontTile != null && frontTile is Empty)
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

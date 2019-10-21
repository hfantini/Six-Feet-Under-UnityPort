using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tile
{
    // == VAR & CONST ========================================================================================================

    protected const int MOVEMENT_DELAY = 150;
    protected float lastMovement = 0;

    // == METHODS ============================================================================================================

    public Player( ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
        this._faceDirection = TileFaceDirection.RIGHT;
        this._sprite = Resources.Load<Sprite>("Sprites/WALK01");
    }

    public override void update()
    {
        base.update();
        bool move = false;
        Vector2 nextPos = Vector2.zero;

        // CHECK MOVIMENT

        if ( (Time.time * 1000) - lastMovement > MOVEMENT_DELAY)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = true;
                nextPos = this._position + new Vector2(-1, 0);
                lastMovement = Time.time * 1000;
                this._faceDirection = TileFaceDirection.LEFT;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                move = true;
                nextPos = this._position + new Vector2(1, 0);
                lastMovement = Time.time * 1000;
                this._faceDirection = TileFaceDirection.RIGHT;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                move = true;
                nextPos = this._position + new Vector2(0, -1);
                lastMovement = Time.time * 1000;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                move = true;
                nextPos = this._position + new Vector2(0, 1);
                lastMovement = Time.time * 1000;
            }
        }

        // UPDATE MOVEMENT

        if( move )
        {
            Tile colisionTile = this._parent.getTileOnPosition( nextPos );

            if ( !( colisionTile is Wall ) )
            {
                if (colisionTile is Exit)
                {
                    if (((Exit)colisionTile).open)
                    {
                        this._parent.setTilePosition(this, nextPos);

                        // LEVEL FINISHED
                        this._parent.completeLevel();
                    }
                }
                else if (colisionTile is Collectible)
                {
                    if (colisionTile is Gem)
                    {
                        SessionData.score += ((Gem)colisionTile).score;
                        this._parent.collectGem();
                        this._parent.setTilePosition(this, nextPos);
                    }
                    else if (colisionTile is Score)
                    {
                        SessionData.score += ((Score)colisionTile).score;
                        this._parent.setTilePosition(this, nextPos);
                    }
                }

                else
                {
                    this._parent.setTilePosition(this, nextPos);
                }
            }
        }
    }

    // == EVENTS =============================================================================================================
}

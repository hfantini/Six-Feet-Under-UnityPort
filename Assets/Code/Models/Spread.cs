using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : Tile
{
    // == VAR & CONST ========================================================================================================

    protected float _movementDelay = 150;
    protected float _lastMovement = 0;
    protected TileMovementDirection _currentMovementDirection = TileMovementDirection.RIGHT;

    // == METHODS ============================================================================================================

    public Spread(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
        this._lastMovement = Time.time * 1000;
    }

    public override void update()
    {
        base.update();

        if( (Time.time * 1000) - this._lastMovement > this._movementDelay )
        {
            for (int count = 0; count < 4; count++)
            {
                Vector2 movementVector = Vector2.zero;

                switch (this._currentMovementDirection)
                {
                    case TileMovementDirection.RIGHT:
                        movementVector = new Vector2(1, 0);
                        this._currentMovementDirection = TileMovementDirection.DOWN;
                        break;

                    case TileMovementDirection.DOWN:
                        movementVector = new Vector2(0, 1);
                        this._currentMovementDirection = TileMovementDirection.LEFT;
                        break;

                    case TileMovementDirection.LEFT:
                        movementVector = new Vector2(-1, 0);
                        this._currentMovementDirection = TileMovementDirection.UP;
                        break;

                    case TileMovementDirection.UP:
                        movementVector = new Vector2(0, -1);
                        this._currentMovementDirection = TileMovementDirection.RIGHT;
                        break;
                }

                Tile colisionTile = this._parent.getTileOnPosition(this.position + movementVector);

                if (!(colisionTile is Wall) && !(colisionTile is Exit) && !(colisionTile is Gem) && !(colisionTile is Dirt) && !(colisionTile is Spread))
                {
                    if ( (colisionTile is Player) )
                    {
                        if (((Player)colisionTile).elementLifeStatus == ElementLifeStatus.ALIVE)
                        {
                            ((Player)colisionTile).kill(DeathType.MELTED);
                        }
                        else if (((Player)colisionTile).elementLifeStatus == ElementLifeStatus.DEATH)
                        {
                            this._parent.createTile(this.GetType().Name, this.position + movementVector);
                        }
                    }
                    else
                    {
                        this._parent.createTile(this.GetType().Name, this.position + movementVector);
                    }
                    break;
                }
            }

            this._lastMovement = Time.time * 1000;
        }
    }

    // == EVENTS =============================================================================================================
}

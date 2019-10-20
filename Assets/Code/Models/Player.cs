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
        this._sprite = Resources.Load<Sprite>("Sprites/WALK01");
    }

    public override void update()
    {
        base.update();

        if ( (Time.time * 1000) - lastMovement > MOVEMENT_DELAY)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this._parent.moveTilePosition(this, Movement.LEFT);
                lastMovement = Time.time * 1000;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this._parent.moveTilePosition(this, Movement.RIGHT);
                lastMovement = Time.time * 1000;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                this._parent.moveTilePosition(this, Movement.UP);
                lastMovement = Time.time * 1000;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                this._parent.moveTilePosition(this, Movement.DOWN);
                lastMovement = Time.time * 1000;
            }
        }
    }

    // == EVENTS =============================================================================================================
}

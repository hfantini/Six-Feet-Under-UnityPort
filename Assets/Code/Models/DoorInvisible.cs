using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInvisible : Exit
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DoorInvisible(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/SPACE");
    }

    public override void update()
    {
        base.update();

        if(this.open == true)
        {
            this._sprite = this._sprite = Resources.Load<Sprite>("Sprites/SPACE");
        }
    }

    // == EVENTS =============================================================================================================
}

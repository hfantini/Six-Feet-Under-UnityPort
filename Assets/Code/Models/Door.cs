using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Exit
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Door(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/DOOR");
    }

    // == EVENTS =============================================================================================================
}

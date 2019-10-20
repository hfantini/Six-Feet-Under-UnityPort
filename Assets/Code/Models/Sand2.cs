using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand2 : Dirt
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Sand2(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/SAND2");
    }

    // == EVENTS =============================================================================================================
}

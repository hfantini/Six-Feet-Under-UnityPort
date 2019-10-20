using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Steel(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/STEEL");
    }

    // == EVENTS =============================================================================================================
}

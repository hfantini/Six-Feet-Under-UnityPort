using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Snow(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/SNOW");
    }

    // == EVENTS =============================================================================================================
}

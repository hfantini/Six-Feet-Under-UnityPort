using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Power(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/POWER");
    }

    // == EVENTS =============================================================================================================
}

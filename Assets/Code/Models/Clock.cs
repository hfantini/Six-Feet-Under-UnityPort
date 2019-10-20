using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Clock(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/CLOCK");
    }

    // == EVENTS =============================================================================================================
}

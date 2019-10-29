using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava1 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava1(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 400;
    }

    // == EVENTS =============================================================================================================
}

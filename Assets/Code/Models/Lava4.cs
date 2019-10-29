using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava4 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava4(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 1000;
    }

    // == EVENTS =============================================================================================================
}

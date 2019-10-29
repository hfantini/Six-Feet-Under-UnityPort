using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava2 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava2(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 200;
    }

    // == EVENTS =============================================================================================================
}

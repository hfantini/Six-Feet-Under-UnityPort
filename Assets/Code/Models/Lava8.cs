using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava9 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava9(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 900;
    }

    // == EVENTS =============================================================================================================
}

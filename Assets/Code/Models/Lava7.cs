using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava7 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava7(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 1700;
    }

    // == EVENTS =============================================================================================================
}

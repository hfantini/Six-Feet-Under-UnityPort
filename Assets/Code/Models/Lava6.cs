using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava6 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava6(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 600;
    }

    // == EVENTS =============================================================================================================
}

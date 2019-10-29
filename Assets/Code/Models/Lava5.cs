using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava5 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava5(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 1200;
    }

    // == EVENTS =============================================================================================================
}

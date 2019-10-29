using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava8 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava8(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 800;
    }

    // == EVENTS =============================================================================================================
}

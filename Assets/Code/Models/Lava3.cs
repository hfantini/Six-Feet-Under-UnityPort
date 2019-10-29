using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava3 : Lava
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava3(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._movementDelay = 800;
    }

    // == EVENTS =============================================================================================================
}

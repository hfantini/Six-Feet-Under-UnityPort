using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock1L : Rock1
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock1L(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}

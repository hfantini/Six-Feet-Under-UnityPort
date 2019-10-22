using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock1R : Rock1
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock1R(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

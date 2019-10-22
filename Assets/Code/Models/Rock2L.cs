using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock2L : Rock2
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock2L(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}

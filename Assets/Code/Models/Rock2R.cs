using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock2R : Rock2
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock2R(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

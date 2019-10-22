using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock3R : Rock3
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock3R(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

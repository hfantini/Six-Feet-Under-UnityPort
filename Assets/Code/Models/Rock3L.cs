using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock3L : Rock3
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock3L(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}

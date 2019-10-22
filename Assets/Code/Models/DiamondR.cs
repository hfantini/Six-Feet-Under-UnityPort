using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondR : Diamond
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DiamondR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

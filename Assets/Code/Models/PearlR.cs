using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlR : Pearl
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public PearlR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}
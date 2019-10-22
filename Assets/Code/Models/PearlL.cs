using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlL : Pearl
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public PearlL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}
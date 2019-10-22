using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldR : Emerald
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public EmeraldR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

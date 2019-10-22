using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldL : Emerald
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public EmeraldL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}

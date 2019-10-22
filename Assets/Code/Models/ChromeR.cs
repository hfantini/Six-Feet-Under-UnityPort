using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeR : Chrome
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public ChromeR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

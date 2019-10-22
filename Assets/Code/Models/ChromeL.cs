using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeL : Chrome
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public ChromeL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}

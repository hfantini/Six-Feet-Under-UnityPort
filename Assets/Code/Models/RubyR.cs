using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyR : Ruby
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public RubyR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}
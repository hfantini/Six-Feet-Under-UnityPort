using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyL : Ruby
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public RubyL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}
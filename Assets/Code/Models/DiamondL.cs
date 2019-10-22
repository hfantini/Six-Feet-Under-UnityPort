using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondL : Diamond
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DiamondL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRockR : MarbleRock
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MarbleRockR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

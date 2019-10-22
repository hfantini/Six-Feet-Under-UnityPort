using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRockL : MarbleRock
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MarbleRockL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}

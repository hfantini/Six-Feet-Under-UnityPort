using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapphireR : Sapphire
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public SapphireR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.RIGHT;
    }

    // == EVENTS =============================================================================================================
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapphireL : Sapphire
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public SapphireL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._currentRollSide = RollSide.LEFT;
    }

    // == EVENTS =============================================================================================================
}
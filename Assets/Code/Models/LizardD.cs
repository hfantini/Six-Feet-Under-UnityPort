using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardD : Lizard
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public LizardD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

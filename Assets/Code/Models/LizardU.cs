using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardU : Lizard
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public LizardU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardR : Lizard
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public LizardR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

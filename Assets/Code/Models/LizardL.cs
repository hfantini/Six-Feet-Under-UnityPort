using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardL : Lizard
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public LizardL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

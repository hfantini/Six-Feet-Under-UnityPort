using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilR : Devil
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DevilR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

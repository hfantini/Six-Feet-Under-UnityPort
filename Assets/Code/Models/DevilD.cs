using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilD : Devil
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DevilD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

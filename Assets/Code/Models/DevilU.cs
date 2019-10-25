using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilU : Devil
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DevilU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

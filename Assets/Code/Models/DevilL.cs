using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilL : Devil
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public DevilL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

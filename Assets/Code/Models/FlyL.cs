using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyL : Fly
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FlyL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

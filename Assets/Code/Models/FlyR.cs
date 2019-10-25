using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyR : Fly
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FlyR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

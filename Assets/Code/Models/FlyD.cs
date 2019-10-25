using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyD : Fly
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FlyD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyU : Fly
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FlyU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

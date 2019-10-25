using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogR : Frog
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FrogR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

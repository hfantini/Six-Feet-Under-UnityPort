using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogU : Frog
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FrogU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

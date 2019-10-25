using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogD : Frog
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FrogD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

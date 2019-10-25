using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogL : Frog
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public FrogL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

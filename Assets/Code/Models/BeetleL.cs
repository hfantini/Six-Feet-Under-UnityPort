using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleL : Beetle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public BeetleL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

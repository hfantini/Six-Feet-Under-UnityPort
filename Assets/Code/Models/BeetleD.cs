using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleD : Beetle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public BeetleD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleR : Beetle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public BeetleR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

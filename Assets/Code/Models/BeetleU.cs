using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleU : Beetle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public BeetleU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

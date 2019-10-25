using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderU : Spider
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public SpiderU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

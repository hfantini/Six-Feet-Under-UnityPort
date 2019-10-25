using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderR : Spider
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public SpiderR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

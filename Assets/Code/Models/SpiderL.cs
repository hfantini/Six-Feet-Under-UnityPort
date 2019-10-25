using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderL : Spider
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public SpiderL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

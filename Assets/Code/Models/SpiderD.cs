using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderD : Spider
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public SpiderD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

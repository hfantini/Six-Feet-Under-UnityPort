using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopherD : Gopher
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public GopherD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopherR : Gopher
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public GopherR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

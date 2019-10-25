using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopherL : Gopher
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public GopherL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

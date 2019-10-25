using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopherU : Gopher
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public GopherU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

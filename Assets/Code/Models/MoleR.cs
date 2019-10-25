using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleR : Mole
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MoleR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

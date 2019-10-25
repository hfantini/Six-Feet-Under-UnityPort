using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleU : Mole
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MoleU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

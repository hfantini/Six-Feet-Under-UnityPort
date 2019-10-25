using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleL : Mole
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MoleL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleD : Mole
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MoleD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

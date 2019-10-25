using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatD : Wombat
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public WombatD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

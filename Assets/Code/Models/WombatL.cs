using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatL : Wombat
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public WombatL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

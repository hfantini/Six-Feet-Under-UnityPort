using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatU : Wombat
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public WombatU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

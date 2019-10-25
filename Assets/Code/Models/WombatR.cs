using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatR : Wombat
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public WombatR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

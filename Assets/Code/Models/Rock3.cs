using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock3 : Heavy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock3(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/ROCK3");
    }

    // == EVENTS =============================================================================================================
}

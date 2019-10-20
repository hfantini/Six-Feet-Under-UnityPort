using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Marble(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/MARBLE");
    }

    // == EVENTS =============================================================================================================
}

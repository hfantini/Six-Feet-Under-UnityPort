using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooper : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Cooper(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/COOPER");
    }

    // == EVENTS =============================================================================================================
}

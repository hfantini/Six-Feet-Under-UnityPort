using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copper : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Copper(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/COPPER");
    }

    // == EVENTS =============================================================================================================
}

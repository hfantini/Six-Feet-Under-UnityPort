using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldHorz : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public GoldHorz(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GOLDHORZ");
    }

    // == EVENTS =============================================================================================================
}

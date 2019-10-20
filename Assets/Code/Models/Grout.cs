using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grout : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Grout(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GROUT");
    }

    // == EVENTS =============================================================================================================
}

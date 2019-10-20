using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concrete : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Concrete(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/CONCRETE");
    }

    // == EVENTS =============================================================================================================
}

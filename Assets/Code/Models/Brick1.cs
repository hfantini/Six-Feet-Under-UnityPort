using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick1 : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Brick1(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/BRICK1");
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Wood(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/WOOD");
    }

    // == EVENTS =============================================================================================================
}

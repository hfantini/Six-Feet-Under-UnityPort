using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dollar : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Dollar(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/DOLLAR");
    }

    // == EVENTS =============================================================================================================
}

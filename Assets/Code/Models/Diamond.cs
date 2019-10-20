using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Diamond(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/DIAMOND");
    }

    // == EVENTS =============================================================================================================
}

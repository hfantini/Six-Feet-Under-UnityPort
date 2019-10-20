using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Emerald(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/EMERALD");
    }

    // == EVENTS =============================================================================================================
}

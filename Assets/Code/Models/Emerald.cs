using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : Gem
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Emerald(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/EMERALD");
        this._score = 20;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : Gem
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Ruby(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/RUBY");
        this._score = 10;
    }

    // == EVENTS =============================================================================================================
}

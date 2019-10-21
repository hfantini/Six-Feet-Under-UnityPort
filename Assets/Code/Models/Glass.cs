using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Score
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Glass(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GLASS");
        this._score = 200;
    }

    // == EVENTS =============================================================================================================
}

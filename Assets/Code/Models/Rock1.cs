using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock1 : Heavy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock1(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/ROCK1");
    }

    // == EVENTS =============================================================================================================
}

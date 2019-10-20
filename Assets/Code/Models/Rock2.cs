using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock2 : Heavy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Rock2(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/ROCK2");
    }

    // == EVENTS =============================================================================================================
}

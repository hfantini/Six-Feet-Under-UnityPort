using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : Spread
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lava(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/LAVA");
    }

    // == EVENTS =============================================================================================================
}

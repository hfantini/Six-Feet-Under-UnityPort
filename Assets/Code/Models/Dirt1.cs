using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt1 : Dirt
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Dirt1(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/DIRT1");
    }

    // == EVENTS =============================================================================================================
}

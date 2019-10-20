using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt2 : Dirt
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Dirt2(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/DIRT2");
    }

    // == EVENTS =============================================================================================================
}

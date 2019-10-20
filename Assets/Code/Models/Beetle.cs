using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Beetle(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/BEETLE");
    }

    // == EVENTS =============================================================================================================
}

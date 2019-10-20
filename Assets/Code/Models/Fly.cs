using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Fly(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/FLY");
    }

    // == EVENTS =============================================================================================================
}

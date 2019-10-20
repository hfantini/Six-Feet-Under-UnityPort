using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Turtle(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/TURTLE");
    }

    // == EVENTS =============================================================================================================
}

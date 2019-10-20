using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Frog(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/FROG");
    }

    // == EVENTS =============================================================================================================
}

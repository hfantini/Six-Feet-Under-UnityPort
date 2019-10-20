using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Gopher(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GOPHER");
    }

    // == EVENTS =============================================================================================================
}

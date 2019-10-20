using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Lizard(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/LIZARD");
    }

    // == EVENTS =============================================================================================================
}

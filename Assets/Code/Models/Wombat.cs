using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wombat : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Wombat(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/WOMBAT");
    }

    // == EVENTS =============================================================================================================
}

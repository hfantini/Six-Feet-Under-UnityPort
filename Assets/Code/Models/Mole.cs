using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Mole(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/MOLE");
    }

    // == EVENTS =============================================================================================================
}

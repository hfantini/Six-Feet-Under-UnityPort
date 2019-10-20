using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Heavy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Bomb(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/BOMB");
    }

    // == EVENTS =============================================================================================================
}

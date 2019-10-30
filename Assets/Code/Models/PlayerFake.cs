using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFake : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public PlayerFake(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/WALK00");
    }

    // == EVENTS =============================================================================================================
}

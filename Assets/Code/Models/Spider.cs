using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Spider(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/SPIDER");
    }

    // == EVENTS =============================================================================================================
}

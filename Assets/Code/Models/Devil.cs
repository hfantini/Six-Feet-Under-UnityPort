using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : Enemy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Devil(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/DEVIL");
    }

    // == EVENTS =============================================================================================================
}

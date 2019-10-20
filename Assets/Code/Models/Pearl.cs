using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Pearl(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/PEARL");
    }

    // == EVENTS =============================================================================================================
}

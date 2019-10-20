using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Glass(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GLASS");
    }

    // == EVENTS =============================================================================================================
}

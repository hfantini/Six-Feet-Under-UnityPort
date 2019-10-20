using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrome : Heavy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Chrome(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/CHROME");
    }

    // == EVENTS =============================================================================================================
}

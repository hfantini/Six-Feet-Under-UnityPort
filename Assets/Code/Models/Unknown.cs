using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unknown : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Unknown(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/MISSING_TEXTURE");
    }

    // == EVENTS =============================================================================================================
}

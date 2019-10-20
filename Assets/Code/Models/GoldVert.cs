using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldVert : Wall
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public GoldVert(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GOLDVERT");
    }

    // == EVENTS =============================================================================================================
}

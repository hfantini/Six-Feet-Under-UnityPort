﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand1 : Dirt
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Sand1(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/SAND");
    }

    // == EVENTS =============================================================================================================
}

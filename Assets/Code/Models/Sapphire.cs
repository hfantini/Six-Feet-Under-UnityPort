﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapphire : Collectible
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Sapphire(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/SAPHIRE");
    }

    // == EVENTS =============================================================================================================
}

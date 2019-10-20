using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Dirt
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Grass(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/GRASS");
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Explosion(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_STATIC;
        this._sprite = Resources.Load<Sprite>("Sprites/EXPLODE1");
    }

    // == EVENTS =============================================================================================================
}

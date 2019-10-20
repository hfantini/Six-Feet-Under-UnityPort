using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Enemy(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
    }

    // == EVENTS =============================================================================================================
}

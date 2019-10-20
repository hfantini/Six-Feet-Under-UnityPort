using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Collectible(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
    }

    // == EVENTS =============================================================================================================
}

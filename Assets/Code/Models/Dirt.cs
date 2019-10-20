using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Dirt(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_STATIC;
    }

    // == EVENTS =============================================================================================================
}

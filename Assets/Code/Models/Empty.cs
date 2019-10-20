using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Empty(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_STATIC;
    }

    // == EVENTS =============================================================================================================
}

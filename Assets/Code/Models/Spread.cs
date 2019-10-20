using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Spread(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
    }

    // == EVENTS =============================================================================================================
}

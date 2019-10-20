using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Exit(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_STATIC;
    }

    // == EVENTS =============================================================================================================
}

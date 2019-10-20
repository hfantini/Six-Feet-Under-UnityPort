using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : Tile
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public Heavy(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
    }

    // == EVENTS =============================================================================================================
}

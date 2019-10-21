using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Tile
{
    // == VAR & CONST ========================================================================================================

    bool _open = false;

    // == METHODS ============================================================================================================

    public Exit(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
    }

    // == EVENTS =============================================================================================================

    // == GETTERS AND SETTERS ================================================================================================
    
    public bool open
    {
        get { return this._open; }
        set { this._open = value; }
    }
}

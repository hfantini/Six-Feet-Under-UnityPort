using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    // == VAR & CONST ========================================================================================================

    protected ScriptGame _parent = null;
    
    protected TileType _type = TileType.TYPE_UNKNOWN;
    protected Sprite _sprite = null;
    protected Vector2 _position = new Vector2(-1, -1);
    protected TileFaceDirection _faceDirection = TileFaceDirection.OFF;

    public enum TileFaceDirection
    {
        OFF,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }


    public enum TileType
    {
        TYPE_UNKNOWN,
        TYPE_STATIC,
        TYPE_DYNAMIC
    }

    public enum TileDirection
    {
        DIRECTION_NE,
        DIRECTION_N,
        DIRECTION_NW,
        DIRECTION_E,
        DIRECTION_W,
        DIRECTION_SE,
        DIRECTION_S,
        DIRECTION_SW
    }

    // == METHODS ============================================================================================================

    public Tile( ScriptGame parent, Vector2 initialPos)
    {
        this._parent = parent;
        this._position = initialPos;
    }

    public virtual void update()
    {

    }

    // == EVENTS =============================================================================================================

    // == GETTERS AND SETTERS ================================================================================================

    public TileType type
    {
        get { return this._type; }
    }

    public Sprite sprite
    {
        get { return this._sprite; }
    }

    public Vector2 position
    {
        get { return this._position; }
        set { this._position = value; }
    }

    public TileFaceDirection faceDirection
    {
        get { return this._faceDirection; }
    }
}

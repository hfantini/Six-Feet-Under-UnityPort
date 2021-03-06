﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Tile
{
    // == VAR & CONST ========================================================================================================

    protected bool _detonate = false;
    protected bool _isCollectible = false;

    // == METHODS ============================================================================================================

    public Bomb(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/BOMB");
        this._type = TileType.TYPE_DYNAMIC;
    }

    public virtual void detonate()
    {
        this._detonate = true;
    }

    // == EVENTS =============================================================================================================

    public bool isCollectible
    {
        get { return this._isCollectible; }
    }
}

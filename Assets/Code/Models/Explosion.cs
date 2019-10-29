using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Wall
{
    // == VAR & CONST ========================================================================================================

    private const int EXPLOSION_ANIM_DELAY = 150;
    private float _explosionTime = 0;
    private int _explosionCount = 2;

    // == METHODS ============================================================================================================

    public Explosion(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._type = TileType.TYPE_DYNAMIC;
        this._sprite = Resources.Load<Sprite>("Sprites/EXPLODE1");
        this._explosionTime = Time.time * 1000;
    }

    public override void update()
    {
        base.update();

        if( (Time.time * 1000) - _explosionTime > EXPLOSION_ANIM_DELAY)
        {
            if (this._explosionCount <= 4)
            {
                this._sprite = Resources.Load<Sprite>("Sprites/EXPLODE" + this._explosionCount);
                this._explosionCount++;
            }
            else
            {
                this._parent.createTile("Empty", this._position);
                this._parent.deleteDynamicTile(this);
            }

            this._explosionTime = Time.time * 1000;
        }
    }

    // == EVENTS =============================================================================================================
}

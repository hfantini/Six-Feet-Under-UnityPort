using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Collectible
{
    // == VAR & CONST ========================================================================================================

    protected int _score = 0;

    // == METHODS ============================================================================================================

    public Gem(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        
    }

    // == EVENTS =============================================================================================================

    // == GETTERS AND SETTERS ================================================================================================

    public int score
    {
        get { return this._score; }
    }
}

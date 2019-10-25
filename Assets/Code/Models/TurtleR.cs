using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleR : Turtle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public TurtleR(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.RIGHT;
    }

    // == EVENTS =============================================================================================================
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleL : Turtle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public TurtleL(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.LEFT;
    }

    // == EVENTS =============================================================================================================
}

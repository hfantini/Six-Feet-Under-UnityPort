using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleD : Turtle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public TurtleD(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.DOWN;
    }

    // == EVENTS =============================================================================================================
}

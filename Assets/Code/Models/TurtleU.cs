using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleU : Turtle
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public TurtleU(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._faceDirection = TileFaceDirection.UP;
    }

    // == EVENTS =============================================================================================================
}

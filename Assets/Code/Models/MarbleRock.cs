using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRock : Heavy
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public MarbleRock(ScriptGame parent, Vector2 initialPos) : base(parent, initialPos)
    {
        this._sprite = Resources.Load<Sprite>("Sprites/MRBLROCK");
    }

    // == EVENTS =============================================================================================================
}

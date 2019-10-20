using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUtil
{
    // == VAR & CONST ========================================================================================================

    // == METHODS ============================================================================================================

    public static Type decodeClassFromTileCode(string tileCode)
    {
        Type retValue = null;

        switch( tileCode )
        {
            case "M0":
                retValue = Type.GetType("Player");
                break;

            case ".2":
                retValue = Type.GetType("Sand1");
                break;

            case "D0":
                retValue = Type.GetType("Ruby");
                break;

            case "D1":
                retValue = Type.GetType("Emerald");
                break;

            case "D3":
                retValue = Type.GetType("Diamond");
                break;

            case "D4":
                retValue = Type.GetType("Pearl");
                break;

            case "B1":
                retValue = Type.GetType("GoldVert");
                break;

            case "B2":
                retValue = Type.GetType("GoldHorz");
                break;

            case "B7":
                retValue = Type.GetType("Brick1");
                break;

            case "X0":
                retValue = Type.GetType("Door");
                break;
        }

        return retValue;
    } 

    // == EVENTS =============================================================================================================
}

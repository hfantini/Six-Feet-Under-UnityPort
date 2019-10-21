﻿using System;
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

            case " 0":
                retValue = Type.GetType("Empty");
                break;

            case ".0":
                retValue = Type.GetType("Dirt1");
                break;

            case ".1":
                retValue = Type.GetType("Dirt2");
                break;

            case ".2":
                retValue = Type.GetType("Sand1");
                break;

            case ".4":
                retValue = Type.GetType("Concrete");
                break;

            case "B1":
                retValue = Type.GetType("GoldVert");
                break;

            case "B2":
                retValue = Type.GetType("GoldHorz");
                break;

            case "B3":
                retValue = Type.GetType("Marble");
                break;

            case "B4":
                retValue = Type.GetType("Steel");
                break;

            case "B6":
                retValue = Type.GetType("Snow");
                break;

            case "B7":
                retValue = Type.GetType("Brick1");
                break;

            case "B9":
                retValue = Type.GetType("Grass");
                break;

            case "C0":
                retValue = Type.GetType("Ruby");
                break;

            case "C1":
                retValue = Type.GetType("Emerald");
                break;

            case "C2":
                retValue = Type.GetType("Sapphire");
                break;

            case "C3":
                retValue = Type.GetType("Diamond");
                break;

            case "C4":
                retValue = Type.GetType("Pearl");
                break;

            case "D0":
                retValue = Type.GetType("Ruby");
                break;

            case "D1":
                retValue = Type.GetType("Emerald");
                break;

            case "D2":
                retValue = Type.GetType("Sapphire");
                break;

            case "D3":
                retValue = Type.GetType("Diamond");
                break;

            case "D4":
                retValue = Type.GetType("Pearl");
                break;

            case "E0":
                retValue = Type.GetType("Ruby");
                break;

            case "E1":
                retValue = Type.GetType("Emerald");
                break;

            case "E2":
                retValue = Type.GetType("Sapphire");
                break;

            case "K0":
                retValue = Type.GetType("Clock");
                break;

            case "N0":
                retValue = Type.GetType("Power");
                break;

            case "o0":
                retValue = Type.GetType("Dollar");
                break;

            case "o1":
                retValue = Type.GetType("Glass");
                break;

            case "s0":
                retValue = Type.GetType("Rock1");
                break;

            case "s1":
                retValue = Type.GetType("Rock2");
                break;

            case "s2":
                retValue = Type.GetType("Rock3");
                break;

            case "s3":
                retValue = Type.GetType("Chrome");
                break;

            case "s4":
                retValue = Type.GetType("MarbleRock");
                break;

            case "r0":
                retValue = Type.GetType("Rock1");
                break;

            case "r1":
                retValue = Type.GetType("Rock2");
                break;

            case "r2":
                retValue = Type.GetType("Rock3");
                break;

            case "r3":
                retValue = Type.GetType("Chrome");
                break;

            case "r4":
                retValue = Type.GetType("MarbleRock");
                break;

            case "t0":
                retValue = Type.GetType("Rock1");
                break;

            case "t1":
                retValue = Type.GetType("Rock2");
                break;

            case "t2":
                retValue = Type.GetType("Rock3");
                break;

            case "t3":
                retValue = Type.GetType("Chrome");
                break;

            case "t4":
                retValue = Type.GetType("MarbleRock");
                break;

            case "X0":
                retValue = Type.GetType("Door");
                break;
        }

        return retValue;
    } 

    // == EVENTS =============================================================================================================
}

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

            case "a0":
                retValue = Type.GetType("Mole");
                break;
            case "a1":
                retValue = Type.GetType("Beetle");
                break;

            case "a2":
                retValue = Type.GetType("Devil");
                break;

            case "a3":
                retValue = Type.GetType("Fly");
                break;

            case "a4":
                retValue = Type.GetType("Frog");
                break;

            case "a5":
                retValue = Type.GetType("Gopher");
                break;

            case "a6":
                retValue = Type.GetType("Lizard");
                break;

            case "a7":
                retValue = Type.GetType("Spider");
                break;

            case "a8":
                retValue = Type.GetType("Turtle");
                break;

            case "a9":
                retValue = Type.GetType("Wombat");
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

            case ".3":
                retValue = Type.GetType("Sand2");
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
                retValue = Type.GetType("RubyL");
                break;

            case "C1":
                retValue = Type.GetType("EmeraldL");
                break;

            case "C2":
                retValue = Type.GetType("SapphireL");
                break;

            case "C3":
                retValue = Type.GetType("DiamondL");
                break;

            case "C4":
                retValue = Type.GetType("PearlL");
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
                retValue = Type.GetType("RubyR");
                break;

            case "E1":
                retValue = Type.GetType("EmeraldR");
                break;

            case "E2":
                retValue = Type.GetType("SapphireR");
                break;

            case "E3":
                retValue = Type.GetType("DiamondR");
                break;

            case "E4":
                retValue = Type.GetType("PearlR");
                break; break;

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
                retValue = Type.GetType("Rock1L");
                break;

            case "r1":
                retValue = Type.GetType("Rock2L");
                break;

            case "r2":
                retValue = Type.GetType("Rock3L");
                break;

            case "r3":
                retValue = Type.GetType("ChromeL");
                break;

            case "r4":
                retValue = Type.GetType("MarbleRockL");
                break;

            case "t0":
                retValue = Type.GetType("Rock1R");
                break;

            case "t1":
                retValue = Type.GetType("Rock2R");
                break;

            case "t2":
                retValue = Type.GetType("Rock3R");
                break;

            case "t3":
                retValue = Type.GetType("ChromeR");
                break;

            case "t4":
                retValue = Type.GetType("MarbleRockR");
                break;

            case "X0":
                retValue = Type.GetType("Door");
                break;
        }

        return retValue;
    } 

    // == EVENTS =============================================================================================================
}

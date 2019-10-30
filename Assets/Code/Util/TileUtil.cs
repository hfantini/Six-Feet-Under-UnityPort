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
                retValue = Type.GetType("MoleD");
                break;

            case "a1":
                retValue = Type.GetType("BeetleD");
                break;

            case "a2":
                retValue = Type.GetType("DevilD");
                break;

            case "a3":
                retValue = Type.GetType("FlyD");
                break;

            case "a4":
                retValue = Type.GetType("FrogD");
                break;

            case "a5":
                retValue = Type.GetType("GopherD");
                break;

            case "a6":
                retValue = Type.GetType("LizardD");
                break;

            case "a7":
                retValue = Type.GetType("SpiderD");
                break;

            case "a8":
                retValue = Type.GetType("TurtleD");
                break;

            case "a9":
                retValue = Type.GetType("WombatD");
                break;

            case "b0":
                retValue = Type.GetType("MoleR");
                break;

            case "b1":
                retValue = Type.GetType("BeetleR");
                break;

            case "b2":
                retValue = Type.GetType("DevilR");
                break;

            case "b3":
                retValue = Type.GetType("FlyR");
                break;

            case "b4":
                retValue = Type.GetType("FrogR");
                break;

            case "b5":
                retValue = Type.GetType("GopherR");
                break;

            case "b6":
                retValue = Type.GetType("LizardR");
                break;

            case "b7":
                retValue = Type.GetType("SpiderR");
                break;

            case "b8":
                retValue = Type.GetType("TurtleR");
                break;

            case "b9":
                retValue = Type.GetType("WombatR");
                break;

            case "c0":
                retValue = Type.GetType("MoleU");
                break;

            case "c1":
                retValue = Type.GetType("BeetleU");
                break;

            case "c2":
                retValue = Type.GetType("DevilU");
                break;
            
            case "c3":
                retValue = Type.GetType("FlyU");
                break;

            case "c4":
                retValue = Type.GetType("FrogU");
                break;

            case "c5":
                retValue = Type.GetType("GopherU");
                break;

            case "c6":
                retValue = Type.GetType("LizardU");
                break;

            case "c7":
                retValue = Type.GetType("SpiderU");
                break;

            case "c8":
                retValue = Type.GetType("TurtleU");
                break;

            case "c9":
                retValue = Type.GetType("WombatU");
                break;

            case "d0":
                retValue = Type.GetType("MoleL");
                break;

            case "d1":
                retValue = Type.GetType("BeetleL");
                break;

            case "d2":
                retValue = Type.GetType("DevilL");
                break;

            case "d3":
                retValue = Type.GetType("FlyL");
                break;

            case "d4":
                retValue = Type.GetType("FrogL");
                break;

            case "d5":
                retValue = Type.GetType("GopherL");
                break;

            case "d6":
                retValue = Type.GetType("LizardL");
                break;

            case "d7":
                retValue = Type.GetType("SpiderL");
                break;

            case "d8":
                retValue = Type.GetType("TurtleL");
                break;

            case "d9":
                retValue = Type.GetType("WombatL");
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

            case "B5":
                retValue = Type.GetType("Wood");
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

            case "L0":
                retValue = Type.GetType("Lava0");
                break;

            case "L1":
                retValue = Type.GetType("Lava1");
                break;

            case "L2":
                retValue = Type.GetType("Lava2");
                break;

            case "L3":
                retValue = Type.GetType("Lava3");
                break;

            case "L4":
                retValue = Type.GetType("Lava4");
                break;

            case "L5":
                retValue = Type.GetType("Lava5");
                break;

            case "L6":
                retValue = Type.GetType("Lava6");
                break;

            case "L7":
                retValue = Type.GetType("Lava7");
                break;

            case "L8":
                retValue = Type.GetType("Lava8");
                break;

            case "L9":
                retValue = Type.GetType("Lava9");
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

            case "x0":
                retValue = Type.GetType("DoorInvisible");
                break;

            default:
                retValue = Type.GetType("Unknown");
                break;
        }

        return retValue;
    } 

    // == EVENTS =============================================================================================================
}

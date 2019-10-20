using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionData
{
    private static int _level = 1;

    public static int level
    {
        get { return _level; }
        set { _level = value; }
    }
}

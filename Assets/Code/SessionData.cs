using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionData
{
    private static int _level = 1;
    private static bool _levelTest = false;
    private static int _lives = 2;
    private static double _score = 0;
    private static Exception _lastException = null;

    // == METHODS ======================================================================================

    public static void configureNewGame()
    {
        _level = 1;
        _lives = 2;
        _score = 0;
    }

    // == GETTERS AND SETTERS ======================================================================================

    public static int level
    {
        get { return _level; }
        set { _level = value; }
    }

    public static int lives
    {
        get { return _lives; }
        set { _lives = value; }
    }

    public static double score
    {
        get { return _score; }
        set { _score = value; }
    }

    public static Exception lastException
    {
        get { return _lastException; }
        set { _lastException = value;  }
    }

    public static bool levelTest
    {
        get { return _levelTest; }
    }
}

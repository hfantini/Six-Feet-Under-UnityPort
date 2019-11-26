using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionData
{
    private static int _level = 1;
    private static Tile[,] _levelMap = null;
    private static bool _levelTest = false;
    private static int _lives = 2;
    private static double _score = 0;
    private static string _currentLevelName = null;
    private static Exception _lastException = null;
    private static bool _loadFinished = false;
    private static bool _presentationFinished = false;

    // == METHODS ======================================================================================

    public static void configureNewGame()
    {
        level = 1;
        lives = 2;
        score = 0;
        currentLevelName = null;
        levelMap = null;
        loadFinished = false;
        presentationFinished = false;
    }

    public static void nextLevel()
    {
        level++;
        currentLevelName = null;
        levelMap = null;
        loadFinished = false;
        presentationFinished = false;
    }

    // == GETTERS AND SETTERS ======================================================================================

    public static int level
    {
        get { return _level; }
        set { _level = value; }
    }

    public static Tile[,] levelMap
    {
        get { return _levelMap; }
        set { _levelMap = value; }
    }

    public static bool loadFinished
    {
        get { return _loadFinished; }
        set { _loadFinished = value; }
    }
    public static bool presentationFinished
    {
        get { return _presentationFinished; }
        set { _presentationFinished = value; }
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

    public static string currentLevelName
    {
        get { return _currentLevelName; }
        set { _currentLevelName = value; }
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

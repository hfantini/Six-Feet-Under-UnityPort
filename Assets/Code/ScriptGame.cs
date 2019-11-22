using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ScriptGame : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    protected const int DELAY_AFTER_DEATH = 3000;
    private const int DELAY_COUNT_TIME_SCORE = 300;
    private const int DELAY_AFTER_COUNT_TIME_SCORE = 300;
    private const int DELAY_TRANSITION_OUT = 200;
    private const int DELAY_TRANSITION_OUT_AFTER_COMPLETE = 1000;

    private int _tileSizeX;
    private int _tileSizeY;
    private int _totalTilesInX;
    private int _totalTilesInY;
    private GameState _currentGameState = GameState.LEVEL_PRESENTATION;
    private int _levelDimX = 0;
    private int _levelDimY = 0;
    private int _originalLevelGems = -1;
    private int _levelGems = -1;
    private int _levelBombs = 0;
    private float _originalLevelTime = -1;
    private float _levelTime = -1;
    private float _levelTimeElapsed = 0;
    private float _levelTimeLastScore = 0;
    private float _levelTimeAfterScore = 0;
    private string _levelMusic = null;
    private bool _levelCompleted = false;
    private bool _playerDied = false;
    private float _playerDiedTime = 0;
    private bool _tileMapSyncBeforeStateChange = false;
    private List<string> _levelRawMap = new List<string>();
    private List<Tile> _tileDynamicList = null;
    private List<Tile> _tileDynamicListForExclusion = null;
    private List<Tile> _tileDynamicListForAddition = null;
    private Tile _tilePlayer = null;
    private int[,] _gridSize = null;
    private MapCameraMode _mapCameraMode = MapCameraMode.UNKNOWN;
    private float _gameAreaTileX = -1;
    private float _gameAreaTileY = -1;
    private Vector2 _scrollOffsetX = new Vector2(-1, -1);
    private Vector2 _scrollOffsetY = new Vector2(-1, -1);
    private float _gameAreaOffsetX = -1;
    private float _gameAreaOffsetY = -1;
    private bool _hurrytriggered = false;
    private float _delayTransitionOut = 0;
    private float _delayTransitionOutAfterComplete = 0;
    private bool _transitionOutComplete = false;
    private List<List<GameObject>> _listOfAllObjectsTransition = null;

    private GameObject _mainCamera = null;
    private GameObject _loadingCamera = null;
    private GameObject _gamePanel = null;
    private GameObject _gameHud = null;
    private GameObject _gameStats = null;
    private GameObject _pnlPause = null;
    private GameObject _pnlControl = null;
    private GameObject _pnlOptions = null;
    private GameObject _pnlConfirm = null;
    private GameObject _btnDropBomb = null;
    private Text _gameHudLevel;
    private Text _gameHudGems;
    private Text _gameHudMen;
    private Text _gameHudTime;
    private Text _gameHudScore;
    private Text _gameHudBomb;

    // TUTORIALS
    private GameObject _pnlTutorial = null;
    private GameObject _pnlTutorial1 = null;
    private GameObject _pnlTutorial8 = null;
    private GameObject _pnlTutorial10 = null;

    private AudioSource _musicSource;
    private AudioSource _soundFxSource;

    private AudioClip _musicLevelClip = null;
    private AudioClip _sndFXBreak = null;
    private AudioClip _sndFXChange = null;
    private AudioClip _sndFXClock = null;
    private AudioClip _sndFXDirt = null;
    private AudioClip _sndFXExplosin = null;
    private AudioClip _sndFXGate = null;
    private AudioClip _sndFXGem = null;
    private AudioClip _sndFXGrunt = null;
    private AudioClip _sndFXHurry = null;
    private AudioClip _sndFXLava = null;
    private AudioClip _sndFXNewLife = null;
    private AudioClip _sndFXRockFall = null;
    private AudioClip _sndFXSlop = null;
    private AudioClip _sndFXSlurp = null;

    protected enum MapCameraMode
    {
        UNKNOWN,
        X_Y_SCROLL,
        X_SCROLL,
        Y_SCROLL,
        NO_SCROLL
    }

    protected enum GameState
    {
        LEVEL_PRESENTATION,
        LEVEL_START,
        LEVEL_TUTORIAL,
        PLAYING,
        PAUSE,
        EXIT_CONFIRM,
        EXIT_TO_MENU,
        DEATH,
        COMPLETE,
        NEXT_LEVEL
    }

    // == METHODS ============================================================================================================

    public void playSoundFX( SoundFX soundFX )
    {
        switch (soundFX)
        {
            case SoundFX.BREAK:

                this._soundFxSource.PlayOneShot(this._sndFXBreak);
                break;

            case SoundFX.CHANGE:

                this._soundFxSource.PlayOneShot(this._sndFXChange);
                break;

            case SoundFX.CLOCK:

                this._soundFxSource.PlayOneShot(this._sndFXClock);
                break;

            case SoundFX.DIRT:

                this._soundFxSource.PlayOneShot(this._sndFXDirt);
                break;

            case SoundFX.EXPLOSIN:

                this._soundFxSource.PlayOneShot(this._sndFXExplosin);
                break;

            case SoundFX.GATE:

                this._soundFxSource.PlayOneShot(this._sndFXGate);
                break;

            case SoundFX.GEM:

                this._soundFxSource.PlayOneShot(this._sndFXGem);
                break;

            case SoundFX.GRUNT:

                this._soundFxSource.PlayOneShot(this._sndFXGrunt);
                break;

            case SoundFX.HURRY:

                this._soundFxSource.PlayOneShot(this._sndFXHurry);
                break;

            case SoundFX.LAVA:

                this._soundFxSource.PlayOneShot(this._sndFXLava);
                break;

            case SoundFX.NEWLIFE:

                this._soundFxSource.PlayOneShot(this._sndFXNewLife);
                break;

            case SoundFX.ROCKFALL:

                this._soundFxSource.PlayOneShot(this._sndFXRockFall);
                break;

            case SoundFX.SLOP:

                this._soundFxSource.PlayOneShot(this._sndFXSlop);
                break;

            case SoundFX.SLURP:

                this._soundFxSource.PlayOneShot(this._sndFXSlurp);
                break;
        }
    }

    public void stopSoundFX()
    {

    }

    public bool isPlayerAlive()
    {
        bool retValue = true;

        if( ( (Player) this._tilePlayer).elementLifeStatus != ElementLifeStatus.ALIVE )
        {
            retValue = false;
        }

        return retValue;
    }

    public void setTilePosition(Tile tile, Vector2 newPos)
    {
        createTile("Empty", new Vector2(tile.position.x, tile.position.y));
        SessionData.levelMap[(int)newPos.y, (int)newPos.x] = tile;

        tile.position = newPos;
    }

    public Tile getTileOnPosition(Vector2 pos)
    {
        Tile retValue = null;

        if ( ( pos.y >= 0 && pos.y < SessionData.levelMap.GetLength(0) ) && ( pos.x >= 0 && pos.x < SessionData.levelMap.GetLength(1) ) )
        {
            retValue = SessionData.levelMap[(int)pos.y, (int)pos.x];
        }

        return retValue;
    }

    public void deteleTileFromMap(Vector2 pos)
    {
        SessionData.levelMap[(int)pos.y, (int)pos.x] = null;
    }

    public void createTile(String tileClass, Vector2 pos)
    {
        Tile tile = (Tile)Activator.CreateInstance(Type.GetType(tileClass), new object[] { this, new Vector2(pos.x, pos.y) });
        SessionData.levelMap[(int)pos.y, (int)pos.x] = tile;

        if (tile.type == Tile.TileType.TYPE_DYNAMIC)
        {
            this._tileDynamicListForAddition.Insert(0, tile);
        }
    }

    public void deleteDynamicTile(Tile tile)
    {
        if (tile.type == Tile.TileType.TYPE_DYNAMIC)
        {
            tile.markedForExclusion = true;
            this._tileDynamicListForExclusion.Add(tile);
        }
    }

    public void collectGem()
    {
        if (this._levelGems > 0)
        {
            this._levelGems--;

            if (this._levelGems == 0)
            {
                // OPEN THE EXIT DOOR
                foreach (Tile tile in this._tileDynamicList)
                {
                    if (tile is Exit)
                    {
                        this.playSoundFX(SoundFX.GATE);
                        ((Exit)tile).open = true;
                    }
                }
            }
        }
    }

    public void collectClock()
    {
        this._levelTime += 10;
    }

    public void useBomb()
    {
        if( this._levelBombs > 0 )
        {
            this._levelBombs--;
        }
    }

    public void collectBomb()
    {
        this._levelBombs++;
    }

    public void playerDied()
    {
        this._playerDied = true;
        this._playerDiedTime = Time.time * 1000;
    }

    public void completeLevel()
    {
        this._levelCompleted = true;
    }

    protected void parseLineFromTXT(string line)
    {
        if (line.Contains("="))
        {
            // == PARAMETER

            string[] paramSplit = line.Split('=');

            switch (paramSplit[0])
            {
                case "TITLE":

                    SessionData.currentLevelName = paramSplit[1];
                    break;

                case "GEMS":
                    this._originalLevelGems = Convert.ToInt32(paramSplit[1]);
                    this._levelGems = Convert.ToInt32(paramSplit[1]);
                    break;

                case "SECONDS":
                    this._originalLevelTime = Convert.ToInt32(paramSplit[1]);
                    this._levelTime = Convert.ToInt32(paramSplit[1]);
                    break;

                case "MIDI":
                    this._levelMusic = paramSplit[1].Replace("MIDI", "Music").Replace(".MID", "");
                    this._musicLevelClip = Resources.Load<AudioClip>(this._levelMusic);
                    break;

                case "BOMBS":
                    this._levelBombs = Convert.ToInt32(paramSplit[1]);
                    break;
            }
        }
        else if (line != "\u001a")
        {
            // == MAP FRAGMENT
            _levelRawMap.Add(line);
        }
    }

    protected void prepareGamePanel()
    {
        float gameAreaX = this._gamePanel.GetComponent<RectTransform>().rect.width;
        float gameAreaY = this._gamePanel.GetComponent<RectTransform>().rect.height;

        this._tileSizeX = (int)gameAreaX / 25;
        this._tileSizeY = (int)gameAreaX / 25;

        this._gameAreaTileX = (float)Math.Floor((Double)gameAreaX / (Double)this._tileSizeX);
        this._gameAreaTileY = (float)Math.Floor((Double)gameAreaY / (Double)this._tileSizeY);

        // DEFINE THE CAMERA MODE

        if (SessionData.levelMap.GetLength(0) <= this._gameAreaTileY && SessionData.levelMap.GetLength(1) <= this._gameAreaTileX)
        {
            this._mapCameraMode = MapCameraMode.NO_SCROLL;
        }
        else if (SessionData.levelMap.GetLength(0) > this._gameAreaTileY && SessionData.levelMap.GetLength(1) > this._gameAreaTileX)
        {
            this._mapCameraMode = MapCameraMode.X_Y_SCROLL;
        }
        else
        {
            if (SessionData.levelMap.GetLength(0) > this._gameAreaTileY)
            {
                this._mapCameraMode = MapCameraMode.Y_SCROLL;
            }

            if (SessionData.levelMap.GetLength(1) > this._gameAreaTileX)
            {
                this._mapCameraMode = MapCameraMode.X_SCROLL;
            }
        }

        // CREATE THE TILES BASED ON CAMERA MODE TYPE

        if (this._mapCameraMode == MapCameraMode.NO_SCROLL)
        {
            float tileAreaY = (SessionData.levelMap.GetLength(0) - 1) * this._tileSizeY;
            float tileAreaX = (SessionData.levelMap.GetLength(1) - 1 ) * this._tileSizeX;

            float noUsedAreaY = gameAreaY - tileAreaY;
            float noUsedAreaX = gameAreaX - tileAreaX;

            float offsetY = noUsedAreaY / 2;
            float offsetX = noUsedAreaX / 2;

            // TOTAL TILES IN SCREEN

            this._totalTilesInX = SessionData.levelMap.GetLength(1);
            this._totalTilesInY = SessionData.levelMap.GetLength(0);

            for (int countX = 0; countX < SessionData.levelMap.GetLength(1); countX++)
            {
                for (int countY = 0; countY < SessionData.levelMap.GetLength(0); countY++)
                {
                    GameObject obj = new GameObject();
                    obj.name = "TILE_" + countX + "_" + countY;

                    Image image = obj.AddComponent<Image>();
                    image.color = new Color32(255, 255, 255, 255);

                    obj.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    obj.GetComponent<RectTransform>().SetParent(_gamePanel.transform);
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(offsetX + (countX * this._tileSizeX), -offsetY + (-countY * this._tileSizeY));
                    obj.GetComponent<RectTransform>().sizeDelta = new Vector3(this._tileSizeX, this._tileSizeY);
                    obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
                    obj.SetActive(true);

                    // ANIMATIONS

                    obj.AddComponent<Animator>();
                    Animator animator = obj.GetComponent<Animator>();
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/ANIMC_PNL_TILE");

                }
            }
        }
        else if (this._mapCameraMode == MapCameraMode.X_Y_SCROLL)
        {
            // CALCULATING TILE OFFSET

            // X

            if ((this._gameAreaTileX - 1) % 2 == 0)
            {
                float value = (this._gameAreaTileX - 1) / 2;
                this._scrollOffsetX = new Vector2(value, value);
            }
            else
            {
                double value = (this._gameAreaTileX - 1) / 2;
                this._scrollOffsetX = new Vector2((float)Math.Ceiling(value), (float)Math.Floor(value));
            }

            // BORDER
            this._gameAreaOffsetX = (float)Math.Floor((Double)gameAreaX % (Double)this._tileSizeX) / 2;

            // Y

            if ((this._gameAreaTileY - 1) % 2 == 0)
            {
                float value = (this._gameAreaTileY - 1) / 2;
                this._scrollOffsetY = new Vector2(value, value);
            }
            else
            {
                double value = (this._gameAreaTileY - 1) / 2;
                this._scrollOffsetY = new Vector2((float)Math.Ceiling(value), (float)Math.Floor(value));
            }

            // BORDER
            this._gameAreaOffsetY = (float)Math.Floor((Double)gameAreaY % (Double)this._tileSizeY) / 2;

            // TOTAL TILES IN SCREEN

            this._totalTilesInX = (int) this._gameAreaTileX;
            this._totalTilesInY = (int) this._gameAreaTileY;

            // TILE CREATION

            for (int countX = 0; countX < this._gameAreaTileX; countX++)
            {
                for (int countY = 0; countY < this._gameAreaTileY; countY++)
                {
                    GameObject obj = new GameObject();
                    obj.name = "TILE_" + countX + "_" + countY;

                    Image image = obj.AddComponent<Image>();
                    image.color = new Color32(255, 255, 255, 255);

                    obj.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    obj.GetComponent<RectTransform>().SetParent(_gamePanel.transform);
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(((countX * this._tileSizeX) + (this._tileSizeX / 2)) + this._gameAreaOffsetX, ((-countY * this._tileSizeY) - (this._tileSizeY / 2)) - this._gameAreaOffsetY);
                    obj.GetComponent<RectTransform>().sizeDelta = new Vector3(this._tileSizeX, this._tileSizeY);
                    obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
                    obj.SetActive(true);

                    // ANIMATIONS

                    obj.AddComponent<Animator>();
                    Animator animator = obj.GetComponent<Animator>();
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/ANIMC_PNL_TILE");
                }
            }
        }
        else if (this._mapCameraMode == MapCameraMode.X_SCROLL)
        {
            // CALCULATING TILE OFFSET

            // X

            if ((this._gameAreaTileX - 1) % 2 == 0)
            {
                float value = (this._gameAreaTileX - 1) / 2;
                this._scrollOffsetX = new Vector2(value, value);
            }
            else
            {
                double value = (this._gameAreaTileX - 1) / 2;
                this._scrollOffsetX = new Vector2((float)Math.Ceiling(value), (float)Math.Floor(value));
            }

            // BORDER
            this._gameAreaOffsetX = (float)Math.Floor((Double)gameAreaX % (Double)this._tileSizeX) / 2;

            int totalTileY = SessionData.levelMap.GetLength(0) * this._tileSizeY;
            this._gameAreaOffsetY = (float)Math.Floor(((Double)gameAreaX - (Double)totalTileY) / 2);

            // TOTAL TILES IN SCREEN

            this._totalTilesInX = (int) this._gameAreaTileX;
            this._totalTilesInY = SessionData.levelMap.GetLength(0);

            // TILE CREATION

            for (int countX = 0; countX < this._gameAreaTileX; countX++)
            {
                for (int countY = 0; countY < SessionData.levelMap.GetLength(0); countY++)
                {
                    GameObject obj = new GameObject();
                    obj.name = "TILE_" + countX + "_" + countY;

                    Image image = obj.AddComponent<Image>();
                    image.color = new Color32(255, 255, 255, 255);

                    obj.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    obj.GetComponent<RectTransform>().SetParent(_gamePanel.transform);
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(((countX * this._tileSizeX) + (this._tileSizeX / 2)) + this._gameAreaOffsetX, ((-countY * this._tileSizeY) - (this._tileSizeY / 2)) - this._gameAreaOffsetY);
                    obj.GetComponent<RectTransform>().sizeDelta = new Vector3(this._tileSizeX, this._tileSizeY);
                    obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
                    obj.SetActive(true);

                    // ANIMATIONS

                    obj.AddComponent<Animator>();
                    Animator animator = obj.GetComponent<Animator>();
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/ANIMC_PNL_TILE");
                }
            }
        }
        else if (this._mapCameraMode == MapCameraMode.Y_SCROLL)
        {
            // CALCULATING TILE OFFSET

            // Y

            if ((this._gameAreaTileY - 1) % 2 == 0)
            {
                float value = (this._gameAreaTileY - 1) / 2;
                this._scrollOffsetY = new Vector2(value, value);
            }
            else
            {
                double value = (this._gameAreaTileY - 1) / 2;
                this._scrollOffsetY = new Vector2((float)Math.Ceiling(value), (float)Math.Floor(value));
            }

            // BORDER

            int totalTileX = SessionData.levelMap.GetLength(1) * this._tileSizeX;
            this._gameAreaOffsetX = (float)Math.Floor( ( (Double) gameAreaX - (Double) totalTileX) / 2);

            this._gameAreaOffsetY = (float)Math.Floor((Double)gameAreaY % (Double)this._tileSizeY) / 2;

            // TOTAL TILES IN SCREEN

            this._totalTilesInX = SessionData.levelMap.GetLength(1);
            this._totalTilesInY = (int)this._gameAreaTileY;

            // TILE CREATION

            for (int countX = 0; countX < SessionData.levelMap.GetLength(1); countX++)
            {
                for (int countY = 0; countY < this._gameAreaTileY; countY++)
                {
                    GameObject obj = new GameObject();
                    obj.name = "TILE_" + countX + "_" + countY;

                    Image image = obj.AddComponent<Image>();
                    image.color = new Color32(255, 255, 255, 255);

                    obj.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    obj.GetComponent<RectTransform>().SetParent(_gamePanel.transform);
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(((countX * this._tileSizeX) + (this._tileSizeX / 2)) + this._gameAreaOffsetX, ((-countY * this._tileSizeY) - (this._tileSizeY / 2)) - this._gameAreaOffsetY);
                    obj.GetComponent<RectTransform>().sizeDelta = new Vector3(this._tileSizeX, this._tileSizeY);
                    obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
                    obj.SetActive(true);

                    // ANIMATIONS

                    obj.AddComponent<Animator>();
                    Animator animator = obj.GetComponent<Animator>();
                    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/ANIMC_PNL_TILE");
                }
            }
        }
    }

    private void updateTileDirection(Tile tile, GameObject gameTile)
    {
        if (tile is Player)
        {
            gameTile.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);

            switch (tile.faceDirection)
            {
                case Tile.TileFaceDirection.LEFT:
                    gameTile.GetComponent<RectTransform>().localScale = new Vector2(-1, 1);
                    break;

                case Tile.TileFaceDirection.RIGHT:
                    gameTile.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    break;

                case Tile.TileFaceDirection.UP:

                    break;

                case Tile.TileFaceDirection.DOWN:
                    break;
            }
        }
        else if (tile is Enemy)
        {
            gameTile.GetComponent<RectTransform>().localScale = new Vector2(1, 1);

            switch (tile.faceDirection)
            {
                case Tile.TileFaceDirection.LEFT:

                    gameTile.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 270);
                    break;

                case Tile.TileFaceDirection.RIGHT:

                    gameTile.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 90);
                    break;

                case Tile.TileFaceDirection.UP:

                    gameTile.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 180);
                    break;

                case Tile.TileFaceDirection.DOWN:

                    gameTile.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
                    break;
            }
        }
        else
        {
            gameTile.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            gameTile.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        }
    }

    private void Awake()
    {
        // == OBJECT INITIALIZATION

        this._tileDynamicList = new List<Tile>();
        this._tileDynamicListForExclusion = new List<Tile>();
        this._tileDynamicListForAddition = new List<Tile>();

        // == WORKING WITH CAMERAS

        this._mainCamera = GameObject.Find("CAMERA");
        this._loadingCamera = GameObject.Find("CAMERA_LOADING");
        
        if(this._loadingCamera != null)
        {
            this._mainCamera.GetComponent<Camera>().enabled = false;
            this._loadingCamera.GetComponent<Camera>().enabled = true;
        }

        // == LOAD DATA FROM LEVEL FILE

        String[] lines = null;
        TextAsset txtAsset = null;

        if (SessionData.levelTest == false)
        {
            txtAsset = Resources.Load<TextAsset>("Levels/LEVEL" + SessionData.level);

        }
        else
        {
            txtAsset = Resources.Load<TextAsset>("Levels/LEVEL_TEST");
        }

        lines = txtAsset.text.Split('\n');

        foreach (String line in lines)
        {
            parseLineFromTXT(line.Replace("\r", ""));
        }

        // == GETTING OBJECTS

        this._gamePanel = GameObject.Find("PNL_GAME");
        this._pnlControl = GameObject.Find("PNL_CONTROLS");
        this._btnDropBomb = GameObject.Find("BTN_BOMB");
        this._gameHud = GameObject.Find("PNL_HUD");
        this._gameHudLevel = GameObject.Find("TXT_HUD_LEVEL").GetComponent<Text>();
        this._gameHudGems = GameObject.Find("TXT_HUD_GEM").GetComponent<Text>();
        this._gameHudMen = GameObject.Find("TXT_HUD_MEN").GetComponent<Text>();
        this._gameHudScore = GameObject.Find("TXT_HUD_SCORE").GetComponent<Text>();
        this._gameHudTime = GameObject.Find("TXT_HUD_TIME").GetComponent<Text>();
        this._gameHudBomb = GameObject.Find("TXT_HUD_BOMB").GetComponent<Text>();
        this._gameStats = GameObject.Find("PNL_INFO");
        this._pnlOptions = GameObject.Find("PNL_OPTION");
        this._pnlOptions.SetActive(false);
        this._pnlConfirm = GameObject.Find("PNL_CONFIRM");
        this._pnlConfirm.SetActive(false);
        this._pnlPause = GameObject.Find("PNL_PAUSE");
        this._pnlPause.SetActive(false);
        this._musicSource = GameObject.Find("AUDIO_SOURCE").GetComponent<AudioSource>();
        this._soundFxSource = GameObject.Find("SOUNDFX_SOURCE").GetComponent<AudioSource>();

        // == TUTORIALS

        // 1

        this._pnlTutorial1 = GameObject.Find("PNL_TUTORIAL_1");

        if(Application.platform == RuntimePlatform.Android)
        {
            GameObject.Find("PNL_INPUT_PC").SetActive(false);
        }
        else
        {
            GameObject.Find("PNL_INPUT_MOBILE").SetActive(false);
        }

        this._pnlTutorial1.SetActive(false);

        // 8

        this._pnlTutorial8 = GameObject.Find("PNL_TUTORIAL_8");

        if (Application.platform == RuntimePlatform.Android)
        {
            GameObject.Find("PNL_TUTORIAL_BOMB_PC").SetActive(false);
        }
        else
        {
            GameObject.Find("PNL_TUTORIAL_BOMB_MOBILE").SetActive(false);
        }

        this._pnlTutorial8.SetActive(false);

        // 10

        this._pnlTutorial10 = GameObject.Find("PNL_TUTORIAL_10");
        this._pnlTutorial10.SetActive(false);

        // TUTORIAL PANEL

        this._pnlTutorial = GameObject.Find("PNL_TUTORIAL");
        this._pnlTutorial.SetActive(false);

        // == SOUNDFX CLIPS

        this._sndFXBreak = Resources.Load<AudioClip>("SoundFX/BREAK");
        this._sndFXChange = Resources.Load<AudioClip>("SoundFX/CHANGE");
        this._sndFXClock = Resources.Load<AudioClip>("SoundFX/CLOCK");
        this._sndFXDirt = Resources.Load<AudioClip>("SoundFX/DIRT");
        this._sndFXExplosin = Resources.Load<AudioClip>("SoundFX/EXPLOSIN");
        this._sndFXGate = Resources.Load<AudioClip>("SoundFX/GATE");
        this._sndFXGem = Resources.Load<AudioClip>("SoundFX/GEM");
        this._sndFXGrunt = Resources.Load<AudioClip>("SoundFX/GRUNT");
        this._sndFXHurry = Resources.Load<AudioClip>("SoundFX/HURRY");
        this._sndFXLava = Resources.Load<AudioClip>("SoundFX/LAVA");
        this._sndFXNewLife = Resources.Load<AudioClip>("SoundFX/NEWLIFE");
        this._sndFXRockFall = Resources.Load<AudioClip>("SoundFX/ROCKFALL");
        this._sndFXSlop = Resources.Load<AudioClip>("SoundFX/SLOP");
        this._sndFXSlurp = Resources.Load<AudioClip>("SoundFX/SLURP");

        // == SET MUSIC
        this._musicSource.clip = this._musicLevelClip;

        // == REMOVING OBJECTS
        UnityEngine.Object.DestroyImmediate(GameObject.Find("PNL_TILE"));
    }

    private void Start()
    {
        // == PREPARE OBJECTS
        this._musicSource.loop = true;

        // == DEFINE PLATFORM VALUES

        float dpi = Screen.dpi;

        if(Application.platform == RuntimePlatform.Android)
        {
            this._pnlControl.SetActive(true);
        }
        else
        {
            this._pnlControl.SetActive(false);
        }

        // == CALC MAP DIMENSIONS

        if (this._levelRawMap.Count > 0)
        {
            this._levelDimX = this._levelRawMap[0].Length / 2;
            this._levelDimY = this._levelRawMap.Count;

            SessionData.levelMap = new Tile[this._levelDimY, this._levelDimX];
        }

        // == INITIALIZING MAP OBJECTS

        for (int countY = 0; countY < this._levelRawMap.Count; countY++)
        {
            int mapXCounter = 0;

            for (int countX = 0; countX < this._levelRawMap[countY].Length; countX += 2)
            {
                string code = this._levelRawMap[countY].Substring(countX, 2);
                Type tileType = TileUtil.decodeClassFromTileCode(code);

                if (tileType != null)
                {
                    Tile currentTile = (Tile)Activator.CreateInstance(tileType, new object[] { this, new Vector2(mapXCounter, countY) });
                    SessionData.levelMap[countY, mapXCounter] = currentTile;

                    // TRACKING SOME OBJECTS IN LISTS

                    if (currentTile.type == Tile.TileType.TYPE_DYNAMIC)
                    {
                        this._tileDynamicList.Add(currentTile);

                        if (currentTile is Player)
                        {
                            this._tilePlayer = currentTile;
                        }
                    }

                    mapXCounter++;
                }
            }
        }

        // == WORKING ON GAME PANEL

        prepareGamePanel();
    }

    private bool applyTransitionSceneOut()
    {
        bool retValue = true;

        if (!this._transitionOutComplete)
        {
            if (this._delayTransitionOut == 0)
            {
                this._delayTransitionOut = Time.time * 1000;
            }

            if ((Time.time * 1000) - this._delayTransitionOut > DELAY_TRANSITION_OUT)
            {
                if (transitionSceneOut())
                {
                    this._transitionOutComplete = true;
                    this._delayTransitionOutAfterComplete = Time.time * 1000;
                }

                this._delayTransitionOut = Time.time * 1000;
            }
        }
        else
        {
            if ((Time.time * 1000) - this._delayTransitionOutAfterComplete > DELAY_TRANSITION_OUT_AFTER_COMPLETE)
            {
                retValue = false;
            }
        }

        return retValue;
    }
    private bool transitionSceneOut()
    {
        bool retValue = true;

        // == THIS METHOD EXECUTES ALL ANIMATION TO TRANSITION OUT THE SCENE. IT OCCURS WHEN PLAYER COMPLETES THE LEVEL OR EXIT TO MAIN MENU.

        this._musicSource.Stop();
        this._pnlPause.SetActive(false);

        // == TRANSFORM THE BACKGROUND COLOR TO BLACK

        Animator pnlGameAnimator = this._gamePanel.GetComponent<Animator>();

        if(pnlGameAnimator.GetCurrentAnimatorStateInfo(0).IsName("STATE_BLACK"))
        {
            pnlGameAnimator.Play("TRANSITION_TO_GRAY");
        }
        else if ( !pnlGameAnimator.GetCurrentAnimatorStateInfo(0).IsName("STATE_GREY") )
        {
            retValue = false;
        }

        // == REMOVE TOP AND BOTTOM PANEL

        // TOP

        Animator pnlStatsAnimator = this._gameStats.GetComponent<Animator>();

        if (pnlStatsAnimator.GetCurrentAnimatorStateInfo(0).IsName("STATE_SHOW"))
        {
            pnlStatsAnimator.Play("TRANSITION_TO_HIDE");
        }
        else if( !pnlStatsAnimator.GetCurrentAnimatorStateInfo(0).IsName("STATE_HIDE") )
        {
            retValue = false;
        }

        // BOTTOM

        Animator pnlStatsHud = this._gameHud.GetComponent<Animator>();

        if (pnlStatsHud.GetCurrentAnimatorStateInfo(0).IsName("STATE_SHOW"))
        {
            pnlStatsHud.Play("TRANSITION_TO_HIDE");
        }
        else if (!pnlStatsHud.GetCurrentAnimatorStateInfo(0).IsName("STATE_HIDE"))
        {
            retValue = false;
        }

        // == GRADUALY REMOVE THE GAME TILES

        // CREATE LIST OF TILES BY COLUMN
        if (this._listOfAllObjectsTransition == null)
        {
            this._listOfAllObjectsTransition = new List<List<GameObject>>();

            for (int countX = 0; countX < this._totalTilesInX; countX++)
            {
                List<GameObject> colList = new List<GameObject>();

                for (int countY = 0; countY < this._totalTilesInY; countY++)
                {
                    GameObject target = GameObject.Find("TILE_" + countX + "_" + countY);
                    colList.Add(target);
                }

                this._listOfAllObjectsTransition.Add(colList);
            }
        }

        // NOW WE LOOP OVER THE LIST REMOVING RAMDOMICALLY TILE BY COLUMNS

        for (int countX = 0; countX < this._listOfAllObjectsTransition.Count; countX++)
        {
            List<GameObject> subList = this._listOfAllObjectsTransition[countX];

            if (subList.Count > 0)
            {
                retValue = false;

                int randomIndex = UnityEngine.Random.Range(0, subList.Count);

                GameObject target = subList[randomIndex];
                Animator animator = target.GetComponent<Animator>();

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("STATE_SHOW"))
                {
                    animator.Play("TRANSITION_TO_HIDE");
                }

                subList.RemoveAt(randomIndex);
            }
            else
            {
                continue;
            }
        }

        return retValue;
    }
    private void updateGameView()
    {
        if (this._mapCameraMode == MapCameraMode.NO_SCROLL)
        {
            for (int countY = 0; countY < SessionData.levelMap.GetLength(0); countY++)
            {
                for (int countX = 0; countX < SessionData.levelMap.GetLength(1); countX++)
                {
                    Tile currentTile = SessionData.levelMap[countY, countX];
                    GameObject gameTile = GameObject.Find("TILE_" + countX + "_" + countY);

                    if (currentTile != null)
                    {
                        // UPDATING TILE FACE DIRECTION

                        updateTileDirection(currentTile, gameTile);

                        // UPDATING TILE IMAGE

                        GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().sprite = currentTile.sprite;
                        GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    }
                    else
                    {
                        // EMPTY TILE

                        GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().sprite = null;
                        GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                    }
                }
            }
        }
        else if (this._mapCameraMode == MapCameraMode.X_Y_SCROLL)
        {
            Vector2 playerPos = this._tilePlayer.position;

            int startPosX = 0;
            int startPosY = 0;
            int endPosX = 0;
            int endPosY = 0;

            // X

            if (playerPos.x - this._scrollOffsetX.x < 0)
            {
                startPosX = 0;
                endPosX = (int)(this._scrollOffsetX.x + this._scrollOffsetX.y);
            }
            else if (playerPos.x + this._scrollOffsetX.y > (SessionData.levelMap.GetLength(1) - 1))
            {
                startPosX = (SessionData.levelMap.GetLength(1) - 1) - (int)(this._scrollOffsetX.x + this._scrollOffsetX.y);
                endPosX = (SessionData.levelMap.GetLength(1) - 1);
            }
            else
            {
                startPosX = (int)(playerPos.x - this._scrollOffsetX.x);
                endPosX = (int)(playerPos.x + this._scrollOffsetX.y);
            }

            // Y

            if (playerPos.y - this._scrollOffsetY.x < 0)
            {
                startPosY = 0;
                endPosY = (int)(this._scrollOffsetY.x + this._scrollOffsetY.y);
            }
            else if (playerPos.y + this._scrollOffsetY.y > (SessionData.levelMap.GetLength(0) - 1))
            {
                startPosY = (SessionData.levelMap.GetLength(0) - 1) - (int)(this._scrollOffsetY.x + this._scrollOffsetY.y);
                endPosY = (SessionData.levelMap.GetLength(0) - 1);
            }
            else
            {
                startPosY = (int)(playerPos.y - this._scrollOffsetY.x);
                endPosY = (int)(playerPos.y + this._scrollOffsetY.y);
            }

            for (int countY = startPosY; countY <= endPosY; countY++)
            {
                for (int countX = startPosX; countX <= endPosX; countX++)
                {
                    Tile currentTile = SessionData.levelMap[countY, countX];
                    GameObject gameTile = GameObject.Find("TILE_" + (countX - startPosX) + "_" + (countY - startPosY));

                    if (currentTile != null)
                    {
                        // UPDATING TILE FACE DIRECTION

                        updateTileDirection(currentTile, gameTile);

                        // UPDATING TILE IMAGE

                        gameTile.GetComponent<Image>().sprite = currentTile.sprite;
                        gameTile.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    }
                    else
                    {
                        // EMPTY TILE

                        gameTile.GetComponent<Image>().sprite = null;
                        gameTile.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                    }
                }
            }
        }
        else if (this._mapCameraMode == MapCameraMode.X_SCROLL)
        {
            Vector2 playerPos = this._tilePlayer.position;

            int startPosX = 0;
            int endPosX = 0;

            // X

            if (playerPos.x - this._scrollOffsetX.x < 0)
            {
                startPosX = 0;
                endPosX = (int)(this._scrollOffsetX.x + this._scrollOffsetX.y);
            }
            else if (playerPos.x + this._scrollOffsetX.y > (SessionData.levelMap.GetLength(1) - 1))
            {
                startPosX = (SessionData.levelMap.GetLength(1) - 1) - (int)(this._scrollOffsetX.x + this._scrollOffsetX.y);
                endPosX = (SessionData.levelMap.GetLength(1) - 1);
            }
            else
            {
                startPosX = (int)(playerPos.x - this._scrollOffsetX.x);
                endPosX = (int)(playerPos.x + this._scrollOffsetX.y);
            }

            for (int countY = 0; countY <= SessionData.levelMap.GetLength(0) - 1; countY++)
            {
                for (int countX = startPosX; countX <= endPosX; countX++)
                {
                    Tile currentTile = SessionData.levelMap[countY, countX];
                    GameObject gameTile = GameObject.Find("TILE_" + (countX - startPosX) + "_" + countY);

                    if (currentTile != null)
                    {
                        // UPDATING TILE FACE DIRECTION

                        updateTileDirection(currentTile, gameTile);

                        // UPDATING TILE IMAGE

                        gameTile.GetComponent<Image>().sprite = currentTile.sprite;
                        gameTile.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    }
                    else
                    {
                        // EMPTY TILE

                        gameTile.GetComponent<Image>().sprite = null;
                        gameTile.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                    }
                }
            }
        }
        else if (this._mapCameraMode == MapCameraMode.Y_SCROLL)
        {
            Vector2 playerPos = this._tilePlayer.position;

            int startPosY = 0;
            int endPosY = 0;

            // Y

            if (playerPos.y - this._scrollOffsetY.x < 0)
            {
                startPosY = 0;
                endPosY = (int)(this._scrollOffsetY.x + this._scrollOffsetY.y);
            }
            else if (playerPos.y + this._scrollOffsetY.y > (SessionData.levelMap.GetLength(0) - 1))
            {
                startPosY = (SessionData.levelMap.GetLength(0) - 1) - (int)(this._scrollOffsetY.x + this._scrollOffsetY.y);
                endPosY = (SessionData.levelMap.GetLength(0) - 1);
            }
            else
            {
                startPosY = (int)(playerPos.y - this._scrollOffsetY.x);
                endPosY = (int)(playerPos.y + this._scrollOffsetY.y);
            }

            for (int countY = startPosY; countY <= endPosY; countY++)
            {
                for (int countX = 0; countX <= SessionData.levelMap.GetLength(1) - 1; countX++)
                {
                    Tile currentTile = SessionData.levelMap[countY, countX];
                    GameObject gameTile = GameObject.Find("TILE_" + countX + "_" + (countY - startPosY));

                    if (currentTile != null)
                    {
                        // UPDATING TILE FACE DIRECTION

                        updateTileDirection(currentTile, gameTile);

                        // UPDATING TILE IMAGE

                        gameTile.GetComponent<Image>().sprite = currentTile.sprite;
                        gameTile.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    }
                    else
                    {
                        // EMPTY TILE

                        gameTile.GetComponent<Image>().sprite = null;
                        gameTile.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                    }
                }
            }
        }
    }
    private void updateGameHud()
    {
        // LEVEL
        this._gameHudLevel.text = "LEVEL " + SessionData.level + " - " + SessionData.currentLevelName;

        // GEMS
        this._gameHudGems.text = this._levelGems.ToString();

        // LIVES
        this._gameHudMen.text = SessionData.lives.ToString();

        // SCORE
        this._gameHudScore.text = SessionData.score.ToString();

        // BOMBS
        this._gameHudBomb.text = this._levelBombs.ToString();

        if (this._levelBombs > 0)
        {
            this._btnDropBomb.SetActive(true);
        }
        else
        {
            this._btnDropBomb.SetActive(false);
        }

        // TIME
        if (this._levelTime >= 0)
        {
            this._gameHudTime.text = this._levelTime.ToString();
        }
    }

    private void Update()
    {
        if (_currentGameState == GameState.LEVEL_PRESENTATION)
        {
            SessionData.loadFinished = true;

            if(SessionData.presentationFinished)
            {
                UnityEngine.Object.Destroy(GameObject.Find("CAMERA_LOADING"));
                this._currentGameState = GameState.LEVEL_START;
                this._mainCamera.GetComponent<Camera>().enabled = true;
            }
        }
        else if( _currentGameState == GameState.LEVEL_START )
        {
            this._playerDiedTime = 0;
            this._musicSource.Play();
            this._currentGameState = GameState.LEVEL_TUTORIAL;
        }
        else if (_currentGameState == GameState.LEVEL_TUTORIAL)
        {
            updateGameView();
            updateGameHud();

            // CHECK FOR TUTORIALS
            if (SessionData.level == 1)
            {
                this._pnlTutorial.SetActive(true);
                this._pnlTutorial1.SetActive(true);
            }
            else if (SessionData.level == 8)
            {
                this._pnlTutorial.SetActive(true);
                this._pnlTutorial8.SetActive(true);
            }
            else if (SessionData.level == 10)
            {
                this._pnlTutorial.SetActive(true);
                this._pnlTutorial10.SetActive(true);
            }
            else
            {
                this._currentGameState = GameState.PLAYING;
            }
        }
        else if (_currentGameState == GameState.PLAYING)
        {
            // REMOVING TILE MARKED FOR EXCLUSION
            foreach (Tile tile in this._tileDynamicListForExclusion)
            {
                this._tileDynamicList.Remove(tile);
            }

            // ADDING TILE MARKED FOR INCLUSION
            foreach (Tile tile in this._tileDynamicListForAddition)
            {
                this._tileDynamicList.Add(tile);
            }

            this._tileDynamicListForExclusion.Clear();
            this._tileDynamicListForExclusion.Clear();

            // UPDATING DYNAMIC TILES

            foreach (Tile tile in this._tileDynamicList)
            {
                if (!tile.markedForExclusion)
                {
                    if (tile is Player && this._playerDied)
                    {
                        continue;
                    }

                    tile.update();
                }
            }

            // UPDATING GAME VIEW
            updateGameView();


            // == CHECKING FOR PLAYER LIFE STATUS
            if (this._playerDied)
            {
                if (this._tilePlayer != null)
                {
                    deleteDynamicTile(this._tilePlayer);
                }

                if( (Time.time * 1000) - this._playerDiedTime > DELAY_AFTER_DEATH )
                {
                    this._currentGameState = GameState.DEATH;
                }
            }

            // == CHECKING FOR LEVEL COMPLETION

            if (this._levelCompleted)
            {
                if (this._tileMapSyncBeforeStateChange == false)
                {
                    this._tileMapSyncBeforeStateChange = true;
                }
                else
                {
                    this._currentGameState = GameState.COMPLETE;
                }
            }

            // == UPDATING ELAPSED TIME

            this._levelTimeElapsed += Time.deltaTime;

            if (this._levelTimeElapsed > 1)
            {
                this._levelTime--;
                this._levelTimeElapsed -= 1;
            }

            // == HANDLING WITH TIMER CHECKPOINTS

            if (this._levelTime < 0 && !this._playerDied)
            {
                this._currentGameState = GameState.DEATH;
            }
            else if( this._levelTime == 10 && !this._hurrytriggered )
            {
                this._hurrytriggered = true;
                this.playSoundFX(SoundFX.HURRY);
            }
            else if( this._levelTime != 10 )
            {
                this._hurrytriggered = false;
            }

            // == UPDATING HUD

            updateGameHud();

            // CHECKING FOR PAUSE
            if( Input.GetKeyDown(KeyCode.Escape) )
            {
                this._currentGameState = GameState.PAUSE;
            }

            this._pnlPause.SetActive(false); 
        }
        else if (_currentGameState == GameState.PAUSE)
        {
            this._pnlPause.SetActive(true);
            this._pnlOptions.SetActive(true);
            this._pnlConfirm.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                this._currentGameState = GameState.PLAYING;
            }
        }
        else if (_currentGameState == GameState.EXIT_CONFIRM)
        {
            this._pnlPause.SetActive(true);
            this._pnlOptions.SetActive(false);
            this._pnlConfirm.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                this._currentGameState = GameState.PAUSE;
            }
        }
        else if (_currentGameState == GameState.EXIT_TO_MENU)
        {
            if( !applyTransitionSceneOut() )
            {
                SceneManager.LoadScene("SCENE_MENU");
            }
        }
        else if (_currentGameState == GameState.DEATH)
        {
            if (SessionData.lives > 0)
            {
                SessionData.lives--;
                SceneManager.LoadScene("SCENE_GAME");
            }
            else
            {
                if (!applyTransitionSceneOut())
                {
                    SceneManager.LoadScene("SCENE_GAMEOVER");
                }
            }
        }
        else if (_currentGameState == GameState.COMPLETE)
        {
            if(this._musicSource.isPlaying)
            {
                this._musicSource.Stop();
            }

            if (this._levelTime > 0)
            {
                // COUNTING TIME SCORE
                if (Time.time * 1000 - this._levelTimeLastScore > DELAY_COUNT_TIME_SCORE)
                {
                    if (this._levelTime > 60)
                    {
                        this.playSoundFX(SoundFX.CHANGE);
                        SessionData.score += 60 * 10;
                        this._levelTime -= 60;
                    }
                    else if (this._levelTime < 60 && this._levelTime >= 10)
                    {
                        this.playSoundFX(SoundFX.CHANGE);
                        SessionData.score += 10 * 10;
                        this._levelTime -= 10;
                    }
                    else
                    {
                        this.playSoundFX(SoundFX.CHANGE);
                        SessionData.score += 10;
                        this._levelTime -= 1;
                    }

                    this._levelTimeLastScore = Time.time * 1000;
                }
            }
            else
            {
                this._levelTimeAfterScore = Time.time * 1000;
                this._currentGameState = GameState.NEXT_LEVEL;
            }

            // == UPDATING HUD

            // GEMS
            this._gameHudGems.text = this._levelGems.ToString();

            // LIVES
            this._gameHudMen.text = SessionData.lives.ToString();

            // SCORE
            this._gameHudScore.text = SessionData.score.ToString();

            // TIME
            this._gameHudTime.text = this._levelTime.ToString();
        }
        else if (_currentGameState == GameState.NEXT_LEVEL)
        {
            if (Time.time * 1000 - this._levelTimeAfterScore > DELAY_AFTER_COUNT_TIME_SCORE)
            {
                if (!applyTransitionSceneOut())
                {
                    if (SessionData.level < 25)
                    {
                        SessionData.nextLevel();
                        SceneManager.LoadScene("SCENE_LOADING");
                    }
                    else
                    {
                        SceneManager.LoadScene("SCENE_GAMEWIN");
                    }
                }
            }
        }
    }

    // == EVENTS =============================================================================================================

    public void onTutorialOkPress()
    {
        if (this._currentGameState == GameState.LEVEL_TUTORIAL)
        {
            this._pnlTutorial.SetActive(false);
            this._currentGameState = GameState.PLAYING;
        }
    }

    public void onBombClick()
    {
        ((Player)this._tilePlayer).playerControls.triggerBomb();
    }

    public void onResumeClick()
    {
        if (this._currentGameState == GameState.PAUSE)
        {
            this._currentGameState = GameState.PLAYING;
        }
    }

    public void onMenuClick()
    {
        if (this._currentGameState == GameState.PAUSE)
        {
            this._currentGameState = GameState.EXIT_CONFIRM;
        }
    }

    public void onConfirmYes()
    {
        if (this._currentGameState == GameState.EXIT_CONFIRM)
        {
            this._currentGameState = GameState.EXIT_TO_MENU;
        }           
    }

    public void onConfirmNo()
    {
        if (this._currentGameState == GameState.EXIT_CONFIRM)
        {
            this._currentGameState = GameState.PAUSE;
        }
    }

    // == GETTERS & SETTERS ==================================================================================================

    public int levelBombs
    {
        get { return this._levelBombs; }
    }
}

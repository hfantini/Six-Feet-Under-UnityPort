using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class ScriptGame : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    private const int TILE_SIZE_X = 64;
    private const int TILE_SIZE_Y = 64;

    private string _levelTitle = null;
    private int _levelGems = -1;
    private int _levelTime = -1;
    private string _levelMusic = null;
    private List<string> _levelRawMap = new List<string>();
    private Tile[,] _levelMap = null;
    private int[,] _gridSize = null;
    private MapCameraMode _mapCameraMode = MapCameraMode.UNKNOWN;

    private GameObject _gamePanel = null;
    private GameObject _gameHud = null;

    protected enum MapCameraMode
    {
        UNKNOWN,
        X_Y_SCROLL,
        X_SCROLL,
        Y_SCROLL,
        NO_SCROLL
    }

    // == METHODS ============================================================================================================

    public void setTilePosition(Tile tile, Vector2 newPos)
    {
        this._levelMap[ (int) tile.position.y, (int) tile.position.x] = null;
        this._levelMap[ (int) newPos.y, (int) newPos.x ] = tile;
        tile.position = newPos;
    }

    public void moveTilePosition(Tile tile, Movement mov)
    {
        int posX = (int) tile.position.x;
        int posY = (int) tile.position.y;

        switch( mov )
        {
            case Movement.LEFT:
                posX--;
                break;

            case Movement.RIGHT:
                posX++;
                break;

            case Movement.UP:
                posY--;
                break;

            case Movement.DOWN:
                posY++;
                break;
        }

        if( posX < this._levelMap.GetLength(1) && posY < this._levelMap.GetLength(0) )
        {
            this._levelMap[ (int) tile.position.y, (int) tile.position.x] = null;
            this._levelMap[posY, posX] = tile;
            tile.position = new Vector2(posX, posY);
        }
        
    }

    protected void parseLineFromTXT(string line)
    {
        if( line.Contains("=") )
        {
            // == PARAMETER

            string[] paramSplit = line.Split('=');
            
            switch( paramSplit[0] )
            {
                case "TITLE":

                    this._levelTitle = paramSplit[1];
                    break;

                case "GEMS":
                    this._levelGems =  Convert.ToInt32(paramSplit[1]);
                    break;

                case "SECONDS":
                    this._levelTime = Convert.ToInt32(paramSplit[1]);
                    break;

                case "MIDI":
                    this._levelMusic = paramSplit[1];
                    break;
            }
        }
        else if(line != "\u001a")
        {
            // == MAP FRAGMENT
            _levelRawMap.Add(line);
        }
    }

    protected void prepareGamePanel()
    {
        float gameAreaX = this._gamePanel.GetComponent<RectTransform>().rect.width;
        float gameAreaY = this._gamePanel.GetComponent<RectTransform>().rect.height;
        float gameAreaTileX = (float) Math.Floor( (Double) gameAreaX / (Double) TILE_SIZE_X );
        float gameAreaTileY = (float) Math.Floor( (Double) gameAreaY / (Double) TILE_SIZE_Y );

        // DEFINE THE CAMERA MODE

        if(_levelMap.GetLength(0) < gameAreaTileY && _levelMap.GetLength(1) < gameAreaTileX)
        {
            this._mapCameraMode = MapCameraMode.NO_SCROLL;
        }
        else if(_levelMap.GetLength(0) > gameAreaTileY && _levelMap.GetLength(1) > gameAreaTileX)
        {
            this._mapCameraMode = MapCameraMode.X_Y_SCROLL;
        }
        else
        {
            if(_levelMap.GetLength(0) > gameAreaTileY)
            {
                this._mapCameraMode = MapCameraMode.Y_SCROLL;
            }

            if (_levelMap.GetLength(1) > gameAreaTileX)
            {
                this._mapCameraMode = MapCameraMode.X_SCROLL;
            }
        }

        // CREATE THE TILES BASED ON CAMERA MODE TYPE

        if( this._mapCameraMode == MapCameraMode.NO_SCROLL )
        {
            float tileAreaY = this._levelMap.GetLength(0) * TILE_SIZE_Y;
            float tileAreaX = this._levelMap.GetLength(1) * TILE_SIZE_X;

            float noUsedAreaY = gameAreaY - tileAreaY;
            float noUsedAreaX = gameAreaX - tileAreaX;

            float offsetY = noUsedAreaY / 2;
            float offsetX = noUsedAreaX / 2;

            for (int countX = 0; countX < this._levelMap.GetLength(1) ; countX++)
            {
                for (int countY = 0; countY < this._levelMap.GetLength(0) ; countY++)
                {
                    GameObject obj = new GameObject();
                    obj.name = "TILE_" + countX + "_" + countY;

                    Image image = obj.AddComponent<Image>();
                    image.color = new Color32(255, 255, 255, 255);

                    obj.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
                    obj.GetComponent<RectTransform>().SetParent(_gamePanel.transform);
                    obj.GetComponent<RectTransform>().localPosition = new Vector3( offsetX + (countX * TILE_SIZE_X), -offsetY + (-countY * TILE_SIZE_Y) );
                    obj.GetComponent<RectTransform>().sizeDelta = new Vector3(TILE_SIZE_X, TILE_SIZE_Y);
                    obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
                    obj.SetActive(true);
                }
            }
        }
    }

    void Start()
    {
        // == LOAD DATA FROM LEVEL FILE

        StreamReader reader = new StreamReader(Application.dataPath + "/Levels/LEVEL" + SessionData.level + ".TXT");

        while( !reader.EndOfStream )
        {
            parseLineFromTXT( reader.ReadLine() );
        }

        // == CALC MAP DIMENSIONS

        if (this._levelRawMap.Count > 0 )
        {
            int dimX = this._levelRawMap[0].Length / 2;
            int dimY = this._levelRawMap.Count;

            this._levelMap = new Tile[dimY, dimX];
        }

        // == INITIALIZING MAP OBJECTS

        for( int countY = 0 ; countY < this._levelRawMap.Count ; countY++ )
        {
            int mapXCounter = 0;

            for (int countX = 0; countX < this._levelRawMap[countY].Length ; countX += 2)
            {
                string code = this._levelRawMap[countY].Substring(countX, 2);
                Type tileType = TileUtil.decodeClassFromTileCode(code);

                if (tileType != null)
                {
                    this._levelMap[countY, mapXCounter] = (Tile)Activator.CreateInstance(tileType, new object[] { this, new Vector2(mapXCounter, countY) });
                    mapXCounter++;
                }
            }
        }

        // == WORKING ON GAME PANEL

        this._gamePanel = GameObject.Find("PNL_GAME");
        prepareGamePanel();
    }

    void Update()
    {
        for( int countY = 0 ; countY < _levelMap.GetLength(0) ; countY++ )
        {
            for (int countX = 0; countX < _levelMap.GetLength(1); countX++)
            {
                Tile currentTile = _levelMap[countY, countX];

                if (currentTile != null)
                {
                    if (currentTile.type == Tile.TileType.TYPE_DYNAMIC)
                    {
                        currentTile.update();
                    }

                    GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().sprite = currentTile.sprite;
                    GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
                else
                {
                    GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().sprite = null;
                    GameObject.Find("TILE_" + countX + "_" + countY).GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                }
            }
        }
    }

    // == EVENTS =============================================================================================================
}

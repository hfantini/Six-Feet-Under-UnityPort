using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptLoading : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    private const int MINIMUM_LOAD_TIME = 1000;
    private const int DELAY_TRANSITION_PULSE = 200;
    private const int DELAY_TRANSITION_AFTER = 1000;

    private float _startTime;
    private bool _previewTilesCreated = false;
    private bool _previewTilesRendered = false;
    private float _transitionTime = 0;
    private float _transitionTimeAfter = 0;
    private bool _transitionFinished = false;

    private AsyncOperation _asyncLoad;
    private GameObject _imgLoader;
    private GameObject _txtLevelNumber = null;
    private GameObject _txtLevelName = null;
    private GameObject _pnlPreview = null;
    private List<List<GameObject>> _previewListOfTileToShow = null;


    // == METHODS ============================================================================================================

    void Start()
    {
        Object.DontDestroyOnLoad(this);

        // GET OBJECTS

        this._imgLoader = GameObject.Find("IMG_LOADER");

        this._txtLevelNumber = GameObject.Find("TXT_LEVEL_NUMBER");
        this._txtLevelNumber.SetActive(false);

        this._txtLevelName = GameObject.Find("TXT_LEVEL_TITLE");
        this._txtLevelName.SetActive(false);

        this._pnlPreview = GameObject.Find("PNL_PREVIEW");

        this._startTime = Time.time * 1000;

        // LOAD THE GAMEPLAY SCENE ASYNC

        StartCoroutine( loadGameSceneAsync() );
    }

    private IEnumerator loadGameSceneAsync()
    {
        while( (Time.time * 1000 - this._startTime) < MINIMUM_LOAD_TIME )
        {
            yield return null;
        }

        this._asyncLoad = SceneManager.LoadSceneAsync("SCENE_GAME");
        this._asyncLoad.allowSceneActivation = true;

        while (!_asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void createPreviewTiles()
    {
        Vector2 panelArea = new Vector2(this._pnlPreview.GetComponent<RectTransform>().rect.width, this._pnlPreview.GetComponent<RectTransform>().rect.height);
        Vector2 tileSize = new Vector2((float)System.Math.Floor(panelArea.x / SessionData.levelMap.GetLength(1)), (float)System.Math.Floor(panelArea.y / SessionData.levelMap.GetLength(0)));
        float finalTileSize = 0;
        float offsetX = 0;
        float offsetY = 0;

        if (tileSize.x <= tileSize.y)
        {
            finalTileSize = tileSize.x;
            offsetY = (panelArea.y - (finalTileSize * SessionData.levelMap.GetLength(0))) / 2;
        }
        else
        {
            finalTileSize = tileSize.y;
            offsetX = ( panelArea.x - (finalTileSize * SessionData.levelMap.GetLength(1) ) ) / 2;
        }

        for ( int countX = 0; countX < SessionData.levelMap.GetLength(1); countX++ )
        {
            for (int countY = 0; countY < SessionData.levelMap.GetLength(0); countY++)
            {
                GameObject obj = new GameObject();
                obj.name = "PREVIEW_TILE_" + countX + "_" + countY;

                Image image = obj.AddComponent<Image>();
                image.color = new Color32(255, 255, 255, 0);

                obj.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                obj.GetComponent<RectTransform>().SetParent(this._pnlPreview.transform);
                obj.GetComponent<RectTransform>().localPosition = new Vector3( ( (countX * finalTileSize) + (finalTileSize / 2) ) + offsetX, ( (-countY * finalTileSize) - (finalTileSize / 2) ) + offsetY);
                obj.GetComponent<RectTransform>().sizeDelta = new Vector3(finalTileSize, finalTileSize);
                obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
                obj.SetActive(true);

                // ANIMATIONS

                obj.AddComponent<Animator>();
                Animator animator = obj.GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/ANIMC_PNL_TILE");
                animator.Play("STATE_HIDE");
            }
        }

        ToString();
    }
    
    void Update()
    {
        // UPDATE THE LEVEL NUMBER AND NAME
        if( SessionData.currentLevelName != null )
        {
            this._txtLevelNumber.SetActive(true);
            this._txtLevelNumber.GetComponent<Text>().text = "LEVEL " + SessionData.level;

            this._txtLevelName.SetActive(true);
            this._txtLevelName.GetComponent<Text>().text = SessionData.currentLevelName;

            // ANIMATION

            Animator animatorNumber = this._txtLevelNumber.GetComponent<Animator>();

            if (animatorNumber.GetCurrentAnimatorStateInfo(0).IsName("STATE_HIDE"))
            {
                animatorNumber.Play("TRANSITION_TO_SHOW");
            }

            Animator animatorName = this._txtLevelName.GetComponent<Animator>();

            if (animatorName.GetCurrentAnimatorStateInfo(0).IsName("STATE_HIDE"))
            {
                animatorName.Play("TRANSITION_TO_SHOW");
            }
        }

        if( SessionData.loadFinished )
        {
            if (!this._previewTilesCreated)
            {
                createPreviewTiles();
                this._previewTilesCreated = true;
            }
            else if(!this._previewTilesRendered)
            {
                this._imgLoader.SetActive(false);

                // UPDATE THE TILES

                for (int countY = 0; countY < SessionData.levelMap.GetLength(0); countY++)
                {
                    for (int countX = 0; countX < SessionData.levelMap.GetLength(1); countX++)
                    {
                        Tile currentTile = SessionData.levelMap[countY, countX];
                        GameObject gameTile = GameObject.Find("PREVIEW_TILE_" + countX + "_" + countY);

                        if (currentTile != null)
                        {
                            // UPDATING TILE IMAGE

                            gameTile.GetComponent<Image>().sprite = currentTile.sprite;
                            gameTile.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                        }
                        else
                        {
                            // EMPTY TILE

                            gameTile.GetComponent<Image>().sprite = null;
                            gameTile.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                        }
                    }
                }

                this._previewTilesRendered = true;
            }
            else if(!this._transitionFinished)
            {
                this._imgLoader.SetActive(false);
                bool animationFinished = true;

                if (this._previewListOfTileToShow == null)
                {
                    if (this._previewListOfTileToShow == null)
                    {
                        this._previewListOfTileToShow = new List<List<GameObject>>();

                        for (int countX = 0; countX < SessionData.levelMap.GetLength(1); countX++)
                        {
                            List<GameObject> colList = new List<GameObject>();

                            for (int countY = 0; countY < SessionData.levelMap.GetLength(0); countY++)
                            {
                                GameObject target = GameObject.Find("PREVIEW_TILE_" + countX + "_" + countY);
                                colList.Add(target);
                            }

                            this._previewListOfTileToShow.Add(colList);
                        }
                    }
                }

                // NOW WE LOOP OVER THE LIST REMOVING RAMDOMICALLY TILE BY COLUMNS

                if (Time.time * 1000 - this._transitionTime > DELAY_TRANSITION_PULSE)
                {
                    for (int countX = 0; countX < this._previewListOfTileToShow.Count; countX++)
                    {
                        List<GameObject> subList = this._previewListOfTileToShow[countX];

                        if (subList.Count > 0)
                        {
                            animationFinished = false;

                            int randomIndex = UnityEngine.Random.Range(0, subList.Count);

                            GameObject target = subList[randomIndex];
                            Animator animator = target.GetComponent<Animator>();

                            if (animator.GetCurrentAnimatorStateInfo(0).IsName("STATE_HIDE"))
                            {
                                animator.Play("TRANSITION_TO_SHOW");
                            }

                            subList.RemoveAt(randomIndex);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    this._transitionTime = Time.time * 1000;

                    if(animationFinished)
                    {
                        this._transitionFinished = true;
                        this._transitionTimeAfter = Time.time * 1000;
                    }
                }
            }
            else
            {
                if ( (Time.time * 1000) - this._transitionTimeAfter > DELAY_TRANSITION_AFTER)
                {
                    SessionData.presentationFinished = true;
                }
            }
        }
        else
        {
            this._imgLoader.SetActive(true);
            this._imgLoader.transform.Rotate(new Vector3(0f, 0f, -100f * Time.deltaTime));
        }
    }
}

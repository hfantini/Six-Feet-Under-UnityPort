using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptLoading : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    private const int MINIMUM_LOAD_TIME = 1000;
    private float _startTime;
    private AsyncOperation _asyncLoad;
    private GameObject _imgLoader;

    // == METHODS ============================================================================================================

    void Start()
    {
        // GET OBJECTS
        this._imgLoader = GameObject.Find("IMG_LOADER");

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

        while (!_asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void Update()
    {
        this._imgLoader.transform.Rotate(new Vector3(0f, 0f, -100f * Time.deltaTime));
    }
}

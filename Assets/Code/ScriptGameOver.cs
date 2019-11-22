using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGameOver : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    private Text _txtScoreValue;

    // == METHODS ============================================================================================================

    public void Awake()
    {
        this._txtScoreValue = GameObject.Find("TXT_SCORE_VALUE").GetComponent<Text>();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        this._txtScoreValue.text = SessionData.score.ToString();
    }

    // == EVENTS =============================================================================================================

    public void onClickBackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SCENE_MENU");
    }
}

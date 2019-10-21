using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptException : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    protected Text _txtMessage = null;

    // == METHODS ============================================================================================================

    void Start()
    {
        this._txtMessage = GameObject.Find("TXT_HUD_MESSAGE").GetComponent<Text>();
    }
    
    void Update()
    {
        if(SessionData.lastException != null)
        {
            this._txtMessage.text = SessionData.lastException.Message;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptCredits : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    protected enum State
    {
        ST_IDLE,
        ST_BACK
    }

    private State _currentState = State.ST_IDLE;

    // == METHODS ============================================================================================================

    public void Start()
    {
        
    }

    public void Update()
    {
        if(this._currentState == State.ST_IDLE)
        {

        }
        else if(this._currentState == State.ST_BACK)
        {
            SceneManager.LoadScene("SCENE_MENU");
        }
    }

    protected void changeState( State newState )
    {
        if( newState == State.ST_IDLE )
        {
            this._currentState = newState;
        }
        else if( newState == State.ST_BACK )
        {
            if( this._currentState == State.ST_IDLE )
            {
                this._currentState = newState;
            }
        }
    }

    // == EVENTS =============================================================================================================

    public void onBackClick()
    {
        changeState(State.ST_BACK);
    }
}

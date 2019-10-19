using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    // == VAR & CONST ========================================================================================================

    protected enum State
    {
        ST_IDLE,
        ST_NEWGAME,
        ST_CREDITS,
        ST_EXIT
    }

    private State _currentState = State.ST_IDLE;

    // == OBJ
    private Text txtNewGame;
    private Text txtCredits;
    private Text txtExit;

    // == METHODS ============================================================================================================

    public void Start()
    {

    }

    public void Update()
    {
        if( this._currentState == State.ST_IDLE )
        {

        }
        else if (this._currentState == State.ST_NEWGAME)
        {

        }
        else if (this._currentState == State.ST_CREDITS)
        {
            SceneManager.LoadScene("SCENE_CREDITS");
        }
        else if (this._currentState == State.ST_EXIT)
        {
            Application.Quit();
        }
    }

    private void changeState(State newState)
    {
        if( newState == State.ST_IDLE )
        {
            this._currentState = State.ST_IDLE;
        }
        else if ( newState == State.ST_NEWGAME )
        {
            if( this._currentState == State.ST_IDLE )
            {
                this._currentState = newState;
            }
        }
        else if ( newState == State.ST_CREDITS)
        {
            if (this._currentState == State.ST_IDLE)
            {
                this._currentState = newState;
            }
        }
        else if ( newState == State.ST_EXIT)
        {
            if (this._currentState == State.ST_IDLE)
            {
                this._currentState = newState;
            }
        }
    }

    // == EVENTS =============================================================================================================

    public void onNewGameClick()
    {
        changeState(State.ST_NEWGAME);
    }

    public void onCreditsClick()
    {
        changeState(State.ST_CREDITS);
    }

    public void onExitClick()
    {
        changeState(State.ST_EXIT);
    }

}

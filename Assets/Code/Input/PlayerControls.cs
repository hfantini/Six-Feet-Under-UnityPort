using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerControls
{
    // == VAR & CONST ========================================================================================================

    private const int TOUCH_DROPBOMB_INPUT_DELAY = 200;
    private const int TOUCH_MOVEMENT_THRESHOLD = 25;

    private Vector2 _startTouch = new Vector2(-1, -1);
    private bool _isMoving = false;
    private PlayerControl _lastMovement = PlayerControl.NONE;
    private bool _useBomb = false;

    // == METHODS ============================================================================================================

    public PlayerControls()
    {

    }

    public PlayerControl readPlayerInput()
    {
        PlayerControl retValue = PlayerControl.NONE;

        if (Application.platform == RuntimePlatform.Android)
        {
            // CHECK MOVEMENT: ANDROID

            if (Input.touches.Length > 0)
            {
                bool movedInThisCall = false;
                Touch currentTouch = Input.touches[0];

                if (this._startTouch == new Vector2(-1, -1))
                {
                    this._startTouch = currentTouch.position;
                }

                Vector2 touchCalc = currentTouch.position - this._startTouch;

                // X

                if (touchCalc.x > TOUCH_MOVEMENT_THRESHOLD)
                {
                    retValue = PlayerControl.RIGHT;
                    this._lastMovement = PlayerControl.RIGHT;
                    this._isMoving = true;
                    movedInThisCall = true;
                    this._startTouch = currentTouch.position;
                }
                else if (touchCalc.x < -TOUCH_MOVEMENT_THRESHOLD)
                {
                    retValue = PlayerControl.LEFT;
                    this._lastMovement = PlayerControl.LEFT;
                    this._isMoving = true;
                    movedInThisCall = true;
                    this._startTouch = currentTouch.position;
                }
                else if (touchCalc.y > TOUCH_MOVEMENT_THRESHOLD)
                {
                    retValue = PlayerControl.UP;
                    this._lastMovement = PlayerControl.UP;
                    this._isMoving = true;
                    movedInThisCall = true;
                    this._startTouch = currentTouch.position;
                }
                else if (touchCalc.y < -TOUCH_MOVEMENT_THRESHOLD)
                {
                    retValue = PlayerControl.DOWN;
                    this._lastMovement = PlayerControl.DOWN;
                    this._isMoving = true;
                    movedInThisCall = true;
                    this._startTouch = currentTouch.position;
                }

                if (this._isMoving && !movedInThisCall)
                {
                    retValue = this._lastMovement;
                }
            }
            else
            {
                this._startTouch = new Vector2(-1, -1);
                this._isMoving = false;
                this._lastMovement = PlayerControl.NONE;
            }

            // CHECK THE BOMB TRIGGER

            if (this._useBomb)
            {
                retValue = PlayerControl.BOMB;
                this._useBomb = false;
            }
        }
        else
        {
            // CHECK MOVEMENT: PC

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                retValue = PlayerControl.LEFT;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                retValue = PlayerControl.RIGHT;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                retValue = PlayerControl.UP;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                retValue = PlayerControl.DOWN;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                retValue = PlayerControl.BOMB;
            }
        }

        return retValue;
    }
    public void triggerBomb()
    {
        this._useBomb = true;
    }
}


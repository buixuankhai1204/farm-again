using System;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    private  float xInput;
    private  float yInput;
    private  bool isWalking;
    private  bool isRunning;
    private  bool isIdle;
    private  ToolEffect toolEffect = ToolEffect.none;
    private  bool isCarrying;
    private  bool isUsingToolRight;
    private  bool isUsingToolLeft;
    private  bool isUsingToolUp;
    private  bool isUsingToolDown;
    private  bool isLiftingToolRight;
    private  bool isLiftingToolLeft;
    private  bool isLiftingToolUp;
    private  bool isLiftingToolDown;
    private  bool isSwingingToolRight;
    private  bool isSwingingToolLeft;
    private  bool isSwingingToolUp;
    private  bool isSwingingToolDown;
    private  bool isPickingRight;
    private  bool isPickingLeft;
    private  bool isPickingUp;
    private  bool isPickingDown;
    private bool idleRight;
    private bool idleLeft;
    private bool idleUp;
    private bool idleDown;

    private Rigidbody2D rigidbody2D;
    private Direction playerDirection;

    private float movementSpeed;
    private bool playerInputIsDisable{
        get;
        set;
    }

    protected override  void Awake ()
    {
        base.Awake();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReesetAnimationTriggers();
        PlayerMovementInput();
        PlayerIsWalkingInput();
        
        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect, isUsingToolRight,
            isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isPickingRight,
            isPickingLeft, isPickingUp, isPickingDown, isLiftingToolRight, isLiftingToolLeft,
            isLiftingToolUp, isLiftingToolDown,
            isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
            false, false, false, false);
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }
    private void ReesetAnimationTriggers()
    {
        isWalking = false;
        isRunning = false;
        isIdle= false;
        toolEffect = ToolEffect.none;
        isCarrying= false;
        isUsingToolRight= false;
        isUsingToolLeft= false;
        isUsingToolUp= false;
        isUsingToolDown= false;
        isLiftingToolRight= false;
        isLiftingToolLeft= false;
        isLiftingToolUp= false;
        isLiftingToolDown= false;
        isSwingingToolRight= false;
        isSwingingToolLeft= false;
        isSwingingToolUp= false;
        isSwingingToolDown= false;
        isPickingRight = false;
        isPickingLeft= false;
        isPickingUp= false;
        isPickingDown= false;
    }

    private void PlayerMovementInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (xInput != 0 && yInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0)
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;

            movementSpeed = Settings.runningSpeed;

            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if(yInput > 0)
            {
                playerDirection = Direction.top;
            }
            else
            {
                playerDirection = Direction.down;
            }
        }
        else if(xInput == 0  && yInput == 0)
        {
            isWalking = false;
            isRunning = false;
            isIdle = true;
        }
    }

    private void PlayerIsWalkingInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            movementSpeed = Settings.walkingSpeed;
            isRunning = false;
            isWalking = true;
            isIdle = false;
        }
        else
        {
            movementSpeed = Settings.runningSpeed;
            isRunning = true;
            isWalking = false;
            isIdle = false; 
        }
    }
}

using UnityEngine;

public static class Settings
{
   public static float fadeInSeconds = 0.25f;
   public static float fadeOutSeconds = 0.35f;
   public static float targetAlpha = 0.45f;
   public const float runningSpeed = 5.333f;
   public const float walkingSpeed = 2.666f;

   public static int playerInitialInventoryCapacity = 24;
   public static int playerMaximumInventoryCapacity = 48;
   
   public static int xInput;
   public static int yInput;
   public static int isWalking;
   public static int isRunning;
   public static int toolEffect;
   public static int isCarrying;
   public static int isUsingToolRight;
   public static int isUsingToolLeft;
   public static int isUsingToolUp;
   public static int isUsingToolDown;
   public static int isLiftingToolRight;
   public static int isLiftingToolLeft;
   public static int isLiftingToolUp;
   public static int isLiftingToolDown;
   public static int isSwingingToolRight;
   public static int isSwingingToolLeft;
   public static int isSwingingToolUp;
   public static int isSwingingToolDown;
   public static int isPickingRight;
   public static int isPickingLeft;
   public static int isPickingUp;
   public static int isPickingDown;
   
   //share Animation Parameters
   public static int idleRight;
   public static int idleLeft;
   public static int idleUp;
   public static int idleDown;

   public const string HoeingTool = "Hoe";
   public const string ChoppingTool = "Axe";
   public const string BreakingTool = "PickAxe";
   public const string ReapingTool = "Scythe";
   public const string WateringTool = "Watering Can";
   public const string CollectingTool = "Basket";

   //Time System
   public const float secondsPerGameSecond = 0.012f;
   static Settings()
   {
      xInput = Animator.StringToHash("xInput");
      yInput = Animator.StringToHash("yInput");
      isWalking = Animator.StringToHash("isWalking");
      isRunning = Animator.StringToHash("isRunning");
      toolEffect = Animator.StringToHash("toolEffect");
      isUsingToolRight = Animator.StringToHash("isUsingToolRight");
      isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
      isUsingToolUp = Animator.StringToHash("isUsingToolUp");
      isUsingToolDown = Animator.StringToHash("isUsingToolDown");
      isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
      isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
      isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
      isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
      isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
      isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
      isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
      isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
      isPickingRight = Animator.StringToHash("isPickingRight");
      isPickingLeft = Animator.StringToHash("isPickingLeft");
      isPickingUp = Animator.StringToHash("isPickingUp");
      isPickingDown = Animator.StringToHash("isPickingDown");
      
      //share Animation Parameters
      idleRight = Animator.StringToHash("idleRight");
      idleLeft = Animator.StringToHash("idleLeft");
      idleUp = Animator.StringToHash("idleUp");
      idleDown = Animator.StringToHash("idleDown");
   }
}

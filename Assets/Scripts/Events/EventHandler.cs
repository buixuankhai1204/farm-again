using System;
using System.Collections.Generic;

public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle,
    bool isCarrying,
    ToolEffect toolEffect, bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isPickingRight,
    bool isPickingLeft, bool isPickingUp, bool isPickingDown, bool isLiftingToolRight, bool isLiftingToolLeft,
    bool isLiftingToolUp, bool isLiftingToolDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown, bool idleRight,
    bool idleLeft, bool idleUp, bool idleDown);

public static class EventHandler
{
    public static event MovementDelegate MovementEvent;
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation,
        List<InventoryItem> inventoryItems)
    {
        if (InventoryUpdatedEvent != null)
        {
            InventoryUpdatedEvent(inventoryLocation, inventoryItems);
        }
    }

    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle,
        bool isCarrying,
        ToolEffect toolEffect, bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
        bool isPickingRight,
        bool isPickingLeft, bool isPickingUp, bool isPickingDown, bool isLiftingToolRight, bool isLiftingToolLeft,
        bool isLiftingToolUp, bool isLiftingToolDown,
        bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
        bool idleRight,
        bool idleLeft, bool idleUp, bool idleDown)
    {
        if (MovementEvent != null)
        {
            MovementEvent(inputX, inputY, isWalking, isRunning, isIdle, isCarrying, toolEffect, isUsingToolRight,
                isUsingToolLeft, isUsingToolUp, isUsingToolDown,
                isPickingRight,
                isPickingLeft, isPickingUp, isPickingDown, isLiftingToolRight, isLiftingToolLeft,
                isLiftingToolUp, isLiftingToolDown,
                isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
                idleRight,
                idleLeft, idleUp, idleDown);
        }
    }
}

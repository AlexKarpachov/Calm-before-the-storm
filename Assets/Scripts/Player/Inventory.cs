using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventorySlots[] inventorySlots;

    [System.Serializable]
    class InventorySlots
    {
        public InventoryType inventoryType;
        public int inventoryAmount;
    }

    public int GetCurrentInventory(InventoryType inventoryType)
    {
        return GetInventorySlots(inventoryType).inventoryAmount;
    }

    public void ReduceCurrentInventory(InventoryType inventoryType)
    {
        GetInventorySlots(inventoryType).inventoryAmount--;
    }

    public void IncreaseCurrentInventory(InventoryType inventoryType, int receivedAmount)
    {
        GetInventorySlots(inventoryType).inventoryAmount += receivedAmount;
    }

    InventorySlots GetInventorySlots(InventoryType inventoryType)
    {
        foreach (InventorySlots slots in inventorySlots)
        {
            if (slots.inventoryType == inventoryType)
            {
                return slots;
            }
        }
        return null;
    }
}

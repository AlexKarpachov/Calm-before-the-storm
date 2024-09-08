using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventorySlots[] inventorySlots;

    [Header ("Resources amount")]
    [SerializeField] TextMeshProUGUI axeAmount;
    [SerializeField] TextMeshProUGUI woodAmount;
    [SerializeField] TextMeshProUGUI ropeAmount;
    [SerializeField] TextMeshProUGUI nailsAmount;

    [System.Serializable]
    class InventorySlots
    {
        public InventoryType inventoryType;
        public int inventoryAmount;
    }

    void Start()
    {
        UpdateUI();
    }

    public int GetCurrentInventory(InventoryType inventoryType)
    {
        return GetInventorySlots(inventoryType).inventoryAmount;
    }

    public void ReduceCurrentInventory(InventoryType inventoryType, int spentAmount)
    {
        GetInventorySlots(inventoryType).inventoryAmount-= spentAmount;
        UpdateUI();
    }

    public void IncreaseCurrentInventory(InventoryType inventoryType, int receivedAmount)
    {
        GetInventorySlots(inventoryType).inventoryAmount += receivedAmount;
        UpdateUI();
    }

    void UpdateUI()
    {
        foreach (InventorySlots slots in inventorySlots)
        {
            switch (slots.inventoryType)
            {
                case InventoryType.Axe:
                    axeAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Wood:
                    woodAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Rope:
                    ropeAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Nails:
                    nailsAmount.text = slots.inventoryAmount.ToString();
                    break;
                    // New resources may be added here
            }
        }
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

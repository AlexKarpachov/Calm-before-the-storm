using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventorySlots[] inventorySlots;

    [Header ("Resources amount")]
    [SerializeField] TextMeshProUGUI axeAmount;
    [SerializeField] TextMeshProUGUI pickAxeAmount;
    [SerializeField] TextMeshProUGUI hammerAmount;
    [SerializeField] TextMeshProUGUI woodAmount;
    [SerializeField] TextMeshProUGUI ironAmount;
    [SerializeField] TextMeshProUGUI ropeAmount;
    [SerializeField] TextMeshProUGUI bushAmount;
    [SerializeField] TextMeshProUGUI foodAmount;
    [SerializeField] TextMeshProUGUI waterAmount;

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
                case InventoryType.Pickaxe:
                    pickAxeAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Hammer:
                    hammerAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Wood:
                    woodAmount.text = slots.inventoryAmount.ToString() + "/50";
                    break;
                case InventoryType.Iron:
                    ironAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Rope:
                    ropeAmount.text = slots.inventoryAmount.ToString() + "/200";
                    break;
                case InventoryType.Bush:
                    bushAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Food:
                    foodAmount.text = slots.inventoryAmount.ToString() + "/100";
                    break;
                case InventoryType.Water:
                    waterAmount.text = slots.inventoryAmount.ToString() + "/100";
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

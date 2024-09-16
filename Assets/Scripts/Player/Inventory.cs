using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventorySlots[] inventorySlots;
    [SerializeField] GameObject ToBuildPanel;
    [SerializeField] GameObject RequirementsPanel;
    [SerializeField] GameObject onBoardButton;

    [Header("Resources amount")]
    [SerializeField] TextMeshProUGUI axeAmount;
    [SerializeField] TextMeshProUGUI pickAxeAmount;
    [SerializeField] TextMeshProUGUI hammerAmount;
    [SerializeField] TextMeshProUGUI woodAmount;
    [SerializeField] TextMeshProUGUI ironAmount;
    [SerializeField] TextMeshProUGUI ropeAmount;
    [SerializeField] TextMeshProUGUI bushAmount;
    [SerializeField] TextMeshProUGUI foodAmount;
    [SerializeField] TextMeshProUGUI waterAmount;

    public static bool inventoryIsCollected = false;
    int hammersRequired = 5;
    int woodRequired = 50;
    int ropeRequired = 50;
    int foodRequired = 50;
    int waterRequired = 50;


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
        GetInventorySlots(inventoryType).inventoryAmount -= spentAmount;
        UpdateUI();
        CheckInventoryConditions();
    }

    public void IncreaseCurrentInventory(InventoryType inventoryType, int receivedAmount)
    {
        GetInventorySlots(inventoryType).inventoryAmount += receivedAmount;
        UpdateUI();
        CheckInventoryConditions();
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
                    ropeAmount.text = slots.inventoryAmount.ToString() + "/50";
                    break;
                case InventoryType.Bush:
                    bushAmount.text = slots.inventoryAmount.ToString();
                    break;
                case InventoryType.Food:
                    foodAmount.text = slots.inventoryAmount.ToString() + "/50";
                    break;
                case InventoryType.Water:
                    waterAmount.text = slots.inventoryAmount.ToString() + "/50";
                    break;
                    // New resources may be added here
            }
        }
    }

    void CheckInventoryConditions()
    {
        int hammer = GetCurrentInventory(InventoryType.Hammer);
        int wood = GetCurrentInventory(InventoryType.Wood);
        int rope = GetCurrentInventory(InventoryType.Rope);
        int foodAmount = GetCurrentInventory(InventoryType.Food);
        int waterAmount = GetCurrentInventory(InventoryType.Water);

        if (hammer >= hammersRequired && wood >= woodRequired && rope >= ropeRequired && !ShipBuilder.isBuilt)
        {
            inventoryIsCollected = true;
            RequirementsPanel.SetActive(false);
            ToBuildPanel.SetActive(true);
        }

        if (foodAmount >= foodRequired && waterAmount >= waterRequired && ShipBuilder.isBuilt)
        {
            onBoardButton.SetActive(true);
        }
    }

    public void AfterBuildUpdate()
    {
        ReduceCurrentInventory(InventoryType.Hammer, hammersRequired);
        ReduceCurrentInventory(InventoryType.Wood, woodRequired);
        ReduceCurrentInventory(InventoryType.Rope, ropeRequired);
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

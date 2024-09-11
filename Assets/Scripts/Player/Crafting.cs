using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    InventoryType inventoryType;

    public CraftingReq Hammer;
    public CraftingReq Axe;
    public CraftingReq Pickaxe;
    public CraftingReq Rope;

   
    public void HammerCrafting()
    {
        if (inventory.GetCurrentInventory(InventoryType.Wood) >= Hammer.woodRequired && 
            inventory.GetCurrentInventory(InventoryType.Iron) >= Hammer.ironRequired)
        {
            inventory.ReduceCurrentInventory(InventoryType.Wood, Hammer.woodRequired);
            inventory.ReduceCurrentInventory(InventoryType.Iron, Hammer.ironRequired);
            inventory.IncreaseCurrentInventory(InventoryType.Hammer, Hammer.numberCrafted);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    public void AxeCrafting()
    {
        if (inventory.GetCurrentInventory(InventoryType.Wood) >= Axe.woodRequired &&
            inventory.GetCurrentInventory(InventoryType.Iron) >= Axe.ironRequired)
        {
            inventory.ReduceCurrentInventory(InventoryType.Wood, Axe.woodRequired);
            inventory.ReduceCurrentInventory(InventoryType.Iron, Axe.ironRequired);
            inventory.IncreaseCurrentInventory(InventoryType.Axe, Axe.numberCrafted);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    public void PickaxeCrafting()
    {
        if (inventory.GetCurrentInventory(InventoryType.Wood) >= Pickaxe.woodRequired &&
            inventory.GetCurrentInventory(InventoryType.Iron) >= Pickaxe.ironRequired)
        {
            inventory.ReduceCurrentInventory(InventoryType.Wood, Pickaxe.woodRequired);
            inventory.ReduceCurrentInventory(InventoryType.Iron, Pickaxe.ironRequired);
            inventory.IncreaseCurrentInventory(InventoryType.Pickaxe, Pickaxe.numberCrafted);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    public void RopeCrafting()
    {
        if (inventory.GetCurrentInventory(InventoryType.Bush) >= Rope.bushRequired)
        {
            inventory.ReduceCurrentInventory(InventoryType.Bush, Rope.bushRequired);
            inventory.IncreaseCurrentInventory(InventoryType.Rope, Rope.numberCrafted);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }
}

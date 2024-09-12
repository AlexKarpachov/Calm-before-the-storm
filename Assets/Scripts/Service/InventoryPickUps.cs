using UnityEngine;

public class InventoryPickUps : MonoBehaviour
{
    [SerializeField] int itemAmount = 5;
    [SerializeField] InventoryType inventoryType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Inventory>().IncreaseCurrentInventory(inventoryType, itemAmount);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class IronPickUp : MonoBehaviour
{
    [SerializeField] int itemAmount = 2;
    [SerializeField] InventoryType inventoryType;

    bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Z))
        {
            FindObjectOfType<Inventory>().IncreaseCurrentInventory(inventoryType, itemAmount);
            Destroy(gameObject);
        }
    }
}

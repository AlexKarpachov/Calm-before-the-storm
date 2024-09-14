using UnityEngine;

public class IronMining : MonoBehaviour
{
    [SerializeField] int requiredHits = 3;
    [SerializeField] int amountToAdd = 5;
    [SerializeField] Inventory inventory;
    [SerializeField] InventoryType inventoryType;
    [SerializeField] GameObject pickaxe;

    GameObject currentIron = null;

    int currentHits = 0;
    float destroyTime = 1;
    bool playerInTrigger = false;

    private void Start()
    {
        pickaxe.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Iron"))
        {
            pickaxe.SetActive(true);
            playerInTrigger = true;
            currentIron = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Iron"))
        {
            playerInTrigger = false;
            pickaxe.SetActive(false);
            currentHits = 0;
            currentIron = null;
        }
    }
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.X))
        {
            currentHits++;

            if (currentHits >= requiredHits && currentIron != null)
            {
                inventory.IncreaseCurrentInventory(inventoryType, amountToAdd);
                Destroy(currentIron, destroyTime);
                currentIron = null;
                currentHits = 0;
                pickaxe.SetActive(false);
            }
        }
    }
}

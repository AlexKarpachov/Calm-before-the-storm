using UnityEngine;

public class TreeCutting : MonoBehaviour
{
    [SerializeField] int requiredHits = 3;
    [SerializeField] int amountToAdd = 5;
    [SerializeField] Inventory inventory;
    [SerializeField] InventoryType inventoryType;
    [SerializeField] GameObject axePrefab;

    GameObject currentTree = null;

    int axeRequired = 1;
    int currentHits = 0;
    public bool playerInTrigger = false;

    private void Start()
    {
        axePrefab.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        int axe = inventory.GetCurrentInventory(InventoryType.Axe);

        if (axe >= axeRequired)
        {
            if (other.gameObject.CompareTag("Wood"))
            {
                axePrefab.SetActive(true);
                playerInTrigger = true;
                currentTree = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            playerInTrigger = false;
            axePrefab.SetActive(false);
            currentHits = 0;
            currentTree = null;
        }
    }
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.C))
        {
            currentHits++;

            if (currentHits >= requiredHits && currentTree != null)
            {
                inventory.IncreaseCurrentInventory(inventoryType, amountToAdd);
                Destroy(currentTree);
                currentTree = null;
                currentHits = 0;
                axePrefab.SetActive(false);
            }
        }
    }
}

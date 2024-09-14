using UnityEngine;

public class TreeCutting : MonoBehaviour
{
    [SerializeField] int requiredHits = 3;
    [SerializeField] int amountToAdd = 5;
    [SerializeField] Inventory inventory;
    [SerializeField] InventoryType inventoryType;
    [SerializeField] GameObject axe;

    GameObject currentTree = null;

    int currentHits = 0;
    bool playerInTrigger = false;

    private void Start()
    {
        axe.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            axe.SetActive(true);
            playerInTrigger = true;
            currentTree = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            playerInTrigger = false;
            axe.SetActive(false);
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
                axe.SetActive(false);
            }   
        }
    }
}

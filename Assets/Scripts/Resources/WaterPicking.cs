using UnityEngine;

public class WaterPicking : MonoBehaviour
{
    [SerializeField] GameObject emptyBucket; 
    [SerializeField] GameObject waterBucket; 
    [SerializeField] Inventory inventory; 
    [SerializeField] InventoryType inventoryType; 
    [SerializeField] int amountToAdd = 10;

    bool hasWater = false; 

    void Start()
    {
        emptyBucket.SetActive(false);
        waterBucket.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lake") && !GameManager.DoomsdayHasStarted)
        {
            waterBucket.SetActive(true); 
            hasWater = true; 
        }

        if (other.CompareTag("Boat") && hasWater)
        {
            waterBucket.SetActive(false); 
            emptyBucket.SetActive(true); 
            hasWater = false; 

            inventory.IncreaseCurrentInventory(inventoryType, amountToAdd);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boat") && !hasWater)
        {
            emptyBucket.SetActive(false); 
        }
    }
}

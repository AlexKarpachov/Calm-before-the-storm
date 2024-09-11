using UnityEngine;

public class InventoryPickUps : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] InventoryType inventoryType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Inventory>().IncreaseCurrentInventory(inventoryType, ammoAmount);
            Destroy(gameObject);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Inventory>().IncreaseCurrentInventory(inventoryType, ammoAmount);
            Destroy(gameObject);
        }
    }*/
}

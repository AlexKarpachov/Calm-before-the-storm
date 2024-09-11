using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;

    bool isInventoryUIActive = false;


    public void InventoryWindowOpener()
    {
        isInventoryUIActive = !isInventoryUIActive;
        inventoryUI.SetActive(isInventoryUIActive);
    }
}

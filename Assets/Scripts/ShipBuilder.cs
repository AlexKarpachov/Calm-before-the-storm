using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBuilder : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject requirementsPanel;
    [SerializeField] GameObject ToBuildPanel;
    [SerializeField] GameObject FoodCollectPanel;
    [SerializeField] GameObject cabin;
    [SerializeField] GameObject roof;
    [SerializeField] GameObject windows;

    public static bool isBuilt = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !Inventory.inventoryIsCollected)
        {
            requirementsPanel.SetActive (true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            requirementsPanel.SetActive(false);
        }
    }

    public void BuildShip()
    {
        isBuilt = true;
        cabin.SetActive (true);
        roof.SetActive (true);
        windows.SetActive (true);
        ToBuildPanel.SetActive (false);
        FoodCollectPanel.SetActive (true);
        inventory.AfterBuildUpdate();
    }
}

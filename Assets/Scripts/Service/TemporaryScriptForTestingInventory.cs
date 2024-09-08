using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryScriptForTestingInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;

    bool isInventoryUIActive = false;


    void Update()
    {
     if (Input.GetKeyDown(KeyCode.E))
        {
            isInventoryUIActive = !isInventoryUIActive;
            inventoryUI.SetActive(isInventoryUIActive);
        }   
    }
}

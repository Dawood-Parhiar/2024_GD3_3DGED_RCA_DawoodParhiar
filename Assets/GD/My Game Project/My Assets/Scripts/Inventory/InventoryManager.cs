using System;
using UnityEngine;

/// <summary>
/// Simple manager to respond to inventory related events
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    [Header("Inventory Menu Toggle")]
    public GameObject inventoryMenu;
    private bool menuActivated = false;
    private void Update()
    {
        if (Input.GetButtonDown("Inventory")&& menuActivated)
        {
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            menuActivated = true;
        }
       
    }

    public void HandleItemPickup(ItemData data)
    {
        //if we have this item then count++
        if (inventory.Contents.ContainsKey(data))
        {
            int count = inventory.Contents[data];
            count++;
            inventory.Contents[data] = count;
        }
        //else set item and count = 1
        else
        {
            inventory.Contents.Add(data, 1);
        }
    }
}
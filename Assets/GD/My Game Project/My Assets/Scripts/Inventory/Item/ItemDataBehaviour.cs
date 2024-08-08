using System;
using UnityEngine;

public class ItemDataBehaviour : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    private InventoryManager inventoryManager;
    public ItemData ItemData { get => itemData; protected set => itemData = value; }

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            
        }
    }
}
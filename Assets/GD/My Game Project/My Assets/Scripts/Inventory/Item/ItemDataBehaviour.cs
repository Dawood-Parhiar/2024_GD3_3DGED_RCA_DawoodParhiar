using System;
using UnityEngine;

public class ItemDataBehaviour : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    public bool pickedUp;
    private InventoryManager inventoryManager;
    public ItemData ItemData { get => itemData; protected set => itemData = value; }

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
}
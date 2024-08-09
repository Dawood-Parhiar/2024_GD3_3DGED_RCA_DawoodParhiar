using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemSlot : MonoBehaviour
{
    //======ItemData======//
    
    public ItemData itemData;
    public bool isFull;
    
    //======Item Slot======//
    [SerializeField]
    private TMP_Text quantityText;
    
    [SerializeField]
    private Image itemImage;
    
    public void AddItem(ItemData newItem)
    {
        itemData = newItem;
        itemImage.sprite = itemData.WaypointIcon;
        itemImage.enabled = true;
        isFull = true;
        quantityText.text = itemData.Value.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemData.WaypointIcon;
    }
    
    public void UpdateQuantity(int newQuantity)
    {
        itemData.Value = newQuantity;
        quantityText.text = itemData.Value.ToString();
    }
}

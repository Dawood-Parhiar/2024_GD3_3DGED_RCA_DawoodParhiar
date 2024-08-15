using System;
using GD;
using GD.My_Game_Project.My_Assets.Scripts.HealthSystem;
using GD.My_Game_Project.My_Assets.Scripts.Inventory.Events;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private ItemDataGameEvent OnPickup;

    [SerializeField]
    private string targetTag = "Collectible";
    
    [SerializeField]
    private string targetTag2 = "Chest";
    
    [SerializeField]
    private string consumable = "Consumable";

    private void GetChestItems(GameObject[] obj)
    {
        foreach (GameObject item in obj)
        {
            Debug.Log("Player got " + item.name);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var itemDataBehaviour = other.gameObject.GetComponent<ItemDataBehaviour>();

        if (other.gameObject.tag.Equals(targetTag))
        {
            //try to get the data from the pickup
              if (itemDataBehaviour != null)
            {
                if (!itemDataBehaviour.pickedUp)
                {
                    //set the item as picked up
                    itemDataBehaviour.pickedUp = true;
                    
                    //raise the event (tell the EventManager that this thing happened)
                    OnPickup?.Raise(itemDataBehaviour.ItemData);

                    //play where item was
                    AudioSource.PlayClipAtPoint(itemDataBehaviour.ItemData.PickupClip,
                        other.gameObject.transform.position);

                    Destroy(other.gameObject);
                }
            }
        }
        else if (other.gameObject.tag.Equals(targetTag2))
        {
            LootBox box = other.gameObject.GetComponent<LootBox>();
            if (box != null)
            {
                box.Open();
                box.OnBoxOpen += GetChestItems;
            }
        }
        else if (other.gameObject.tag.Equals(consumable))
        {
            itemDataBehaviour.pickedUp = true;
            OnPickup.Raise(itemDataBehaviour.ItemData);
            Destroy(other.gameObject);

            // Increase player's health
            var playerHealth = FindObjectOfType<PlayerHealthBehavior>();
            if (playerHealth != null)
            {
                playerHealth.Heal(50);
            }
        }
    }
}

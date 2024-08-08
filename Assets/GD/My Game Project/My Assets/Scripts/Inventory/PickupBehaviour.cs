using GD;
using GD.My_Game_Project.My_Assets.Scripts.Inventory.Events;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private ItemDataGameEvent OnPickup;

    [SerializeField]
    private string targetTag = "Consumable";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(targetTag))
        {
            //try to get the data from the pickup
            var itemDataBehaviour = other.gameObject.GetComponent<ItemDataBehaviour>();
            if (itemDataBehaviour != null)
            {
                //raise the event (tell the EventManager that this thing happened)
                OnPickup?.Raise(itemDataBehaviour.ItemData);

                //play where item was
                AudioSource.PlayClipAtPoint(itemDataBehaviour.ItemData.PickupClip,
                    other.gameObject.transform.position);

                Destroy(other.gameObject, itemDataBehaviour.ItemData.PickupClip.length);
            }
            else
            {
                Debug.LogWarning("ItemDataBehaviour not found on " + other.gameObject.name);
            }
        }
    }
}

/*
 public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private StringGameEvent OnPickup;

    [SerializeField]
    private string targetTag = "Consumable";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(targetTag))
        {
            OnPickup.Raise("ammo");
            Destroy(other.gameObject);
            //PlaySound()
        }
    }
}

 */
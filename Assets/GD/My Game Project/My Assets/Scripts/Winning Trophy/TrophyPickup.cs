using System.Collections;
using System.Collections.Generic;
using GD.My_Game_Project.My_Assets.Scripts.Managers;
using UnityEngine;

public class TrophyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameWon();
        }
    }
}

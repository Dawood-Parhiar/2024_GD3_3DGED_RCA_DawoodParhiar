using System;
using System.Collections;
using System.Collections.Generic;
using GD.My_Game_Project.My_Assets.Scripts.Interfaces;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    
    // Script Reference: https://www.youtube.com/watch?v=PztRlkqyBMA&t=67s
    
    

    
    public List<IDamagable> damagablesInRange { get; } = new List<IDamagable>();

    public void OnTriggerEnter(Collider other)
    {
        var damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagablesInRange.Add(damagable);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        var damagable = other.GetComponent<IDamagable>();
        if (damagable != null && damagablesInRange.Contains(damagable))
        {
            damagablesInRange.Remove(damagable);
        }
    }
}

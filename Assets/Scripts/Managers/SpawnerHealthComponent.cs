using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealthComponent : HealthComponent
{
    
    public AudioSource hitound;
    private void Awake()
    {
       
    }
    
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this);
        }
        hitound.Play();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthComponent : HealthComponent
{
    ZombieStateMachine zombieStateMachine;
    public AudioSource hitound;
    private void Awake()
    {
        zombieStateMachine = GetComponent<ZombieStateMachine>();
    }
    public override void Destroy()
    {
        zombieStateMachine.ChangeState(ZombieStateType.isDead);
    }
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy();
        }
        hitound.Play();
    }
}

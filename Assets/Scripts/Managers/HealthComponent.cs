using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    [SerializeField]
    public float currentHealth;
    public float CurrentHealth => currentHealth;
    [SerializeField]
    public float maxHealth;
    public float MaxHealth => maxHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }
    public void HealPlayer(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Character_Stats : MonoBehaviour
{
    [SerializeField]
    public float currentHealth;

    [SerializeField]
    public float MaxHealth;

    [SerializeField]
    public bool isDead;

    public virtual void CheckHealth()
    {
        if (currentHealth >= MaxHealth)
        {
            currentHealth = MaxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Die();
        }
    }

    public virtual void Die()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}

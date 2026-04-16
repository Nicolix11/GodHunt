using System;
using UnityEngine;

public class EnemyStats : BaseStats, IDamageable
{
    public event EventHandler OnGetHit;
    
    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100;

    private bool isAlive;
    

    private void Awake()
    {
        isAlive = true;
        
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        
        OnGetHit?.Invoke(this, EventArgs.Empty);
    }

    private void Die()
    {
        Destroy(this.gameObject);

        isAlive = false;
    }
    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetHealthFillAmount()
    {
        return currentHealth / maxHealth;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
}

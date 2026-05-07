using System;
using UnityEngine;

public abstract class EnemyStatsBase : MonoBehaviour, IDamageable
{
    public event EventHandler OnEnemyDie;
    public event EventHandler<OnGetHitEventArgs> OnGetHit;
    public class OnGetHitEventArgs : EventArgs 
    {
        public float damage; 
    }
    
    [Header("Stats")]
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;

    protected bool isAlive;
    

    protected void Awake()
    {
        isAlive = true;
        
        currentHealth = maxHealth;
    }

    public virtual void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        
        OnGetHit?.Invoke(this, new OnGetHitEventArgs{damage = damage});
    }

    protected void Die()
    {
        isAlive = false;

        WaveManager.instance.GetActiveEnemyList().Remove(this.gameObject);
        
        OnEnemyDie?.Invoke(this, EventArgs.Empty);
       
        Destroy(this.gameObject);
    }
    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
}

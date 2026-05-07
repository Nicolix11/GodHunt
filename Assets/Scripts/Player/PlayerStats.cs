using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public static PlayerStats instance;
    
    public event EventHandler OnGetHit;
    public event EventHandler OnCharacterDie;
    public event EventHandler OnCharacterRevive;

    [Header("Components")] 
    [SerializeField] private GlobalPlayerStatsSO globalPlayerStatsSo; 
    
    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100;
    
    private bool isAlive;


    private void Awake()
    {
        instance = this;
        
        isAlive = true;
        
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        
        if(currentHealth <= 0)
        {
            Die();
        }
        
        OnGetHit?.Invoke(this, EventArgs.Empty);
    }

    private void Die()
    {
        isAlive = false;
        
        OnCharacterDie?.Invoke(this, EventArgs.Empty);
    }

    private void Revive()
    {
        currentHealth = maxHealth;

        isAlive = true;
        
        OnCharacterRevive?.Invoke(this, EventArgs.Empty);
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

    public GlobalPlayerStatsSO GetGlobalPlayerStatsSO()
    {
        return globalPlayerStatsSo;
    }
}
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
    [SerializeField] private PlayerInventorySO playerInventory;
     
    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100;
    [Space] 
    [SerializeField] private float earnedGold;
    [SerializeField] private float earnedGems;
    [SerializeField] private float earnedExperience;
    
    private bool isAlive;


    private void Awake()
    {
        instance = this;
        
        isAlive = true;
        
        currentHealth = maxHealth;
    }

    private void Start()
    {
        GameManager.instance.OnRoundFinished += GameManager_OnRoundFinished;
    }

    private void GameManager_OnRoundFinished(object sender, EventArgs e)
    {
        AddProgress();
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
    
    public void AddProgress()
    {
        GetGlobalPlayerStatsSO().AddGold(earnedGold);
        GetGlobalPlayerStatsSO().AddGems(earnedGems);
        GetGlobalPlayerStatsSO().AddExperience(earnedExperience);
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

    private GlobalPlayerStatsSO GetGlobalPlayerStatsSO()
    {
        return globalPlayerStatsSo;
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStats : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GameObject statsObject;
    [SerializeField] private Image healthbarImage;
    
    private PlayerStats playerStats;
    

    private void Awake()
    {
        playerStats = statsObject.GetComponent<PlayerStats>();
    }
    
    private void Start()
    {
        playerStats.OnGetHit += PlayerStatsOnOnGetHit;
        playerStats.OnCharacterDie += PlayerStatsOnOnPlayerDie;
        playerStats.OnCharacterRevive += PlayerStatsOnOnPlayerRevive;
        
        UpdateHealthBar();
    }

    private void PlayerStatsOnOnPlayerRevive(object sender, EventArgs e)
    {
        EnableUI();
    }

    private void PlayerStatsOnOnPlayerDie(object sender, EventArgs e)
    {
        DisableUI();
    }

    private void PlayerStatsOnOnGetHit(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
    
    private void UpdateHealthBar()
    {
        healthbarImage.fillAmount = GetHealthFillAmount();
    }
    
    public float GetHealthFillAmount()
    {
        return playerStats.GetCurrentHealth() / playerStats.GetMaxHealth();
    }

    private void EnableUI()
    {
        gameObject.SetActive(true);   
    }

    private void DisableUI()
    {
        gameObject.SetActive(false);
    }
}

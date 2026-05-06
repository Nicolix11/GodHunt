using System;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStats : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GameObject statsObject;
    [SerializeField] private Image healthbarImage;
    
    private PlayerStats _playerStats;
    

    private void Awake()
    {
        _playerStats = statsObject.GetComponent<PlayerStats>();
    }
    
    private void Start()
    {
        _playerStats.OnGetHit += PlayerStatsOnOnGetHit;
        _playerStats.OnCharacterDie += PlayerStatsOnOnPlayerDie;
        _playerStats.OnCharacterRevive += PlayerStatsOnOnPlayerRevive;
        
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
        healthbarImage.fillAmount = _playerStats.GetHealthFillAmount();
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

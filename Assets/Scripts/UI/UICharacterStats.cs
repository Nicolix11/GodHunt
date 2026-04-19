using System;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterStats : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GameObject statsObject;
    [SerializeField] private Image healthbarImage;
    
    private CharacterStats characterStats;
    

    private void Awake()
    {
        characterStats = statsObject.GetComponent<CharacterStats>();
    }
    
    private void Start()
    {
        characterStats.OnGetHit += CharacterStatsOnOnGetHit;
        characterStats.OnCharacterDie += CharacterStatsOnOnCharacterDie;
        characterStats.OnCharacterRevive += CharacterStatsOnOnCharacterRevive;
        
        UpdateHealthBar();
    }

    private void CharacterStatsOnOnCharacterRevive(object sender, EventArgs e)
    {
        EnableUI();
    }

    private void CharacterStatsOnOnCharacterDie(object sender, EventArgs e)
    {
        DisableUI();
    }

    private void CharacterStatsOnOnGetHit(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
    
    private void UpdateHealthBar()
    {
        healthbarImage.fillAmount = characterStats.GetHealthFillAmount();
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

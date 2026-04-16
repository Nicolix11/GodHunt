using System;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyStats : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GameObject statsObject;
    [SerializeField] private Image healthbarImage;
    
    private EnemyStats enemyStats;
    

    private void Awake()
    {
        enemyStats = statsObject.GetComponent<EnemyStats>();
    }
    
    private void Start()
    {
        enemyStats.OnGetHit += CharacterStatsOnOnGetHit;
        
        UpdateHealthBar();
    }

    private void CharacterStatsOnOnGetHit(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
    
    private void UpdateHealthBar()
    {   
        healthbarImage.fillAmount = enemyStats.GetHealthFillAmount();
    }
}

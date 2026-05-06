using System;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyStats : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GameObject statsObject;
    [SerializeField] private Image healthbarImage;
    
    private EnemyStatsBase _enemyStatsBase;
    

    private void Awake()
    {
        _enemyStatsBase = statsObject.GetComponent<EnemyStatsBase>();
    }
    
    private void Start()
    {
        _enemyStatsBase.OnGetHit += CharacterStatsBaseOnOnGetHit;
        
        UpdateHealthBar();
    }

    private void CharacterStatsBaseOnOnGetHit(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
    
    private void UpdateHealthBar()
    {   
        healthbarImage.fillAmount = _enemyStatsBase.GetHealthFillAmount();
    }
}

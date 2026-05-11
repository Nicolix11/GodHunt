using System;
using TMPro;
using UnityEngine;

public class UIGlobalPlayerStats : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private GlobalPlayerStatsSO globalPlayerStatsSo;
    
    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI gemsText;

    private void Update()
    {
        UpdateGlobalPlayerStatsText();
    }

    private void UpdateGlobalPlayerStatsText()
    {
        goldText.text = globalPlayerStatsSo.GetGold().ToString();
        experienceText.text = globalPlayerStatsSo.GetExperience().ToString();
        gemsText.text = globalPlayerStatsSo.GetGems().ToString();
    }
}

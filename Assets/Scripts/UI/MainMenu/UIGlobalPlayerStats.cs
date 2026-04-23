using System;
using TMPro;
using UnityEngine;

public class UIGlobalPlayerStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI gemsText;


    private void Update()
    {
        UpdateGlobalPlayerStatsText();
    }

    private void UpdateGlobalPlayerStatsText()
    {
        goldText.text = GlobalPlayerStatsManager.instance.GetGoldAmount().ToString();
        experienceText.text = GlobalPlayerStatsManager.instance.GetExperienceAmount().ToString();
        gemsText.text = GlobalPlayerStatsManager.instance.GetGemsAmount().ToString();
    }
}

using System;
using UnityEngine;

public class GlobalPlayerStatsManager : MonoBehaviour
{
    public static GlobalPlayerStatsManager instance { get; private set; }
    
    [SerializeField] private int gold;
    [SerializeField] private int gems;
    [SerializeField] private int experience;


    private void Awake()
    {
        instance = this;
    }

    public int GetGoldAmount()
    {
        return gold;
    }

    public int GetGemsAmount()
    {
        return gems;
    }

    public int GetExperienceAmount()
    {
        return experience;
    }
}
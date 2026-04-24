using UnityEngine;

[CreateAssetMenu]
public class GlobalPlayerStatsSO : ScriptableObject
{
    public float gold;
    public float experience;
    public float gems;
    
    
    public void AddGold(float addedGold)
    {
        gold += addedGold;
    }

    public void AddExperience(float addedExperience)
    {
        experience += addedExperience;
    }

    public void AddGems(float addedGems)
    {
        gems += addedGems;
    }
}

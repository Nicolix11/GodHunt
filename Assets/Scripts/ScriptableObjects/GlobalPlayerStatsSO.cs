using UnityEngine;

[CreateAssetMenu]
public class GlobalPlayerStatsSO : ScriptableObject
{
    [SerializeField] private float gold;
    [SerializeField] private float experience;
    [SerializeField] private float gems;
    
    
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

    public float GetGold()
    {
        return gold;
    }

    public float GetGems()
    {
        return gems;
    }

    public float GetExperience()
    {
        return experience;
    }
}

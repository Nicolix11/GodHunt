using UnityEngine;

[CreateAssetMenu]
public class BreastplateSO : ScriptableObject
{
    [Header("Components")] 
    [SerializeField] private GameObject armorPrefab;
    
    [Header("Properties")]
    [SerializeField] private string armorName;
    [SerializeField] private float defense;


    public GameObject GetArmorPrefab()
    {
        return armorPrefab;
    }
}

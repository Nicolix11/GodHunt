using UnityEngine;

[CreateAssetMenu]
public class WeaponSO : ScriptableObject
{
    [Header("Components")] 
    [SerializeField] private GameObject weaponPrefab;
    
    [Header("Properties")]
    [SerializeField] private string weaponName;
    [SerializeField] private float damage;


    public GameObject GetWeaponPrefab()
    {
        return weaponPrefab;
    }
}

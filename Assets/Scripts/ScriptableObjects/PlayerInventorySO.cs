using UnityEngine;

[CreateAssetMenu]
public class PlayerInventorySO : ScriptableObject
{
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private HelmetSO HelmetSO;
    [SerializeField] private BreastplateSO breastplateSO;
    [SerializeField] private GreavesSO greavesSO;
    [SerializeField] private SabatonSO sabatonSO;
}

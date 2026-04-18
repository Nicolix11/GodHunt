using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBaseAttackVisual : MonoBehaviour
{
    [FormerlySerializedAs("objectIstRotating")] [SerializeField] private bool objectIsRotating;
    [SerializeField] private float rotSpeed = 1200f;
    
    
    void Update()
    {
        RotateProjectile();
    }
    
    private void RotateProjectile()
    {
        if (objectIsRotating)
        {
            transform.Rotate(Vector3.right * (Time.deltaTime * rotSpeed));
        }
    }
}

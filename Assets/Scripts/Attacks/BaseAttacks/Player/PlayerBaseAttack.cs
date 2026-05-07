using UnityEngine;

public class PlayerBaseAttack : BaseAttack
{
    protected override void OnTriggerEnter(Collider other)
    {
        IDamageable hitObject = other.gameObject.GetComponent<IDamageable>();

        if (hitObject != null && other.CompareTag(ENEMY))
        {
            hitObject.ApplyDamage(baseAttackDamage);
            Destroy(gameObject);
        }
        else if (other.CompareTag(ENVIROMENT))
        {
            Destroy(gameObject);
        }
    }
}

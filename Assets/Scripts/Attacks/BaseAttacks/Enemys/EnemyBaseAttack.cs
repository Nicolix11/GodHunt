using UnityEngine;

public class EnemyBaseAttack : BaseAttack
{
    protected override void OnTriggerEnter(Collider other)
    {
        IDamageable hitObject = other.gameObject.GetComponent<IDamageable>();

        if (hitObject != null && other.CompareTag(PLAYER))
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

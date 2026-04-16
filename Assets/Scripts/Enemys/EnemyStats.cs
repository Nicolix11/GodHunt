using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Debug.Log("Enemy Health:" + currentHealth);
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}

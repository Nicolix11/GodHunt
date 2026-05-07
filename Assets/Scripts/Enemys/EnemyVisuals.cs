using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyVisuals : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnemyStatsBase enemyStatsBase;
    [SerializeField] private GameObject hitVisual;
    [SerializeField] private GameObject hitText;
    [Space]
    [SerializeField] private Transform hitParticleSpawnPoint;
    [SerializeField] private ParticleSystem hitParticle;
    
    [Header("Attributes")]
    [SerializeField] private float visualHitWhiteningEffectDuration = 0.15f;
    
    private void Start()
    {
        enemyStatsBase.OnGetHit += EnemyStatsBaseOnGetHit;
    }

    private void EnemyStatsBaseOnGetHit(object sender, EnemyStatsBase.OnGetHitEventArgs e)
    {
        VisualHitWhiteningEffect();
        VisualHitNumbers(e.damage);
        SpawnHitParticles();
    }

    private void SpawnHitParticles()
    {
        Instantiate(hitParticle, hitParticleSpawnPoint);
    }

    private void VisualHitNumbers(float damage)
    {
        
    }

    private void VisualHitWhiteningEffect()
    {
        StartCoroutine(VisualHitWhiteningEffectCoroutine());
    }
    
    IEnumerator VisualHitWhiteningEffectCoroutine()
    {
        hitVisual.SetActive(true);

        yield return new WaitForSeconds(visualHitWhiteningEffectDuration);
        
        hitVisual.SetActive(false);
    }
}

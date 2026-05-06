using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyVisuals : MonoBehaviour
{
    [FormerlySerializedAs("enemyStats")]
    [Header("Components")]
    [SerializeField] private EnemyStatsBase enemyStatsBase;
    [SerializeField] private GameObject hitVisual;
    [SerializeField] private GameObject hitText;
    
    [FormerlySerializedAs("visualHitEffectDuration")]
    [Header("Attributes")]
    [SerializeField] private float visualHitWhiteningEffectDuration = 0.1f;
    
    private void Start()
    {
        enemyStatsBase.OnGetHit += EnemyStatsBaseOnGetHit;
    }

    private void EnemyStatsBaseOnGetHit(object sender, EnemyStatsBase.OnGetHitEventArgs e)
    {
        VisualHitWhiteningEffect();
        VisualHitNumbers(e.damage);
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

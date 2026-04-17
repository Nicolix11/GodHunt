using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [SerializeField] private List<GameObject> activeEnemyList;

    private GameObject nearestEnemy;
    
    private void Awake()
    {
        instance = this;
        //activeEnemyList = new List<GameObject>();
    }
    
    public GameObject GetNearestEnemy()
    {
        // checken ob überhaupt Objekte in der Liste sind
        // sonst ist der Rest überflüssig
        
        foreach (var enemy in activeEnemyList)
        {
            if (enemy != null)
            {
                if (nearestEnemy == null)
                {
                    nearestEnemy = enemy;
                }
                
                Vector3 distanceToPlayer = enemy.transform.position - CharacterController.instance.transform.position;

                Vector3 distanceNearestEnemy =
                    nearestEnemy.transform.position - CharacterController.instance.transform.position;
            
                if (distanceToPlayer.sqrMagnitude < distanceNearestEnemy.sqrMagnitude)
                {
                    nearestEnemy = enemy;
                }
            }
        }    
        
        return nearestEnemy;
    }
    
    public bool IsWaveActive()
    {
        return activeEnemyList.Count != 0; // Fehler: bleibt true auch wenn alle gegner besiegt sind
    }

    public List<GameObject> GetActiveEnemyList()
    {
        return activeEnemyList;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [SerializeField] private List<GameObject> activeEnemyList;

    private bool isWaveActive;

    private GameObject nearestEnemy;
    
    private void Awake()
    {
        instance = this;
        //activeEnemyList = new List<GameObject>();
    }

    private void Update()
    {
        IsWaveActive();
        
        Debug.Log(GetNearestEnemy());
    }

    public GameObject GetNearestEnemy()
    {
        // checken ob überhaupt Objekte in der Liste sind
        // sonst ist der Rest überflüssig
        
        GameObject nearestEnemy = activeEnemyList[0];  
            
        foreach (var enemy in activeEnemyList)
        {
            if (enemy != null)
            {
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

    private void CalculateNearestEnemy()
    {
        
    }
    
    public bool IsWaveActive()
    {
        isWaveActive = activeEnemyList.Count > 0;

        return isWaveActive;
    }
}

using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Portal destinationPortal;
    
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        
        //check if wave is active
        if (player != null)
        {
            MoveCharacter(player);
        }
    }

    private void MoveCharacter(PlayerController player)
    {
        player.transform.position = destinationPortal.ReturnSpawnPointTransform().position;
        player.transform.forward = destinationPortal.transform.position - spawnPoint.transform.position;
    }

    public Transform ReturnSpawnPointTransform()
    {
        return spawnPoint;
    }
}

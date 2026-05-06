using System;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    private const string IS_MOVING = "IsMoving";
    private const string ATTACK = "Attack";
    private const string CHARACTER_DIE = "CharacterDie";
    private const string CHARACTER_REVIVE = "CharacterRevive";
    
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerController.instance.OnAttack += CharacterController_OnAttack;
        PlayerStats.instance.OnCharacterDie += InstanceOnOnCharacterDie;
        PlayerStats.instance.OnCharacterRevive += CharacterStats_OnCharacterRevive;
    }
    
    private void Update()
    {
        animator.SetBool(IS_MOVING, PlayerController.instance.IsMoving());
    }
    
    private void CharacterController_OnAttack(object sender, EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }
    
    private void InstanceOnOnCharacterDie(object sender, EventArgs e)
    {
        animator.SetTrigger(CHARACTER_DIE);
    }
    
    private void CharacterStats_OnCharacterRevive(object sender, EventArgs e)
    {
        animator.SetTrigger(CHARACTER_REVIVE);
    }
}
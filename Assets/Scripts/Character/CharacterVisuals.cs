using System;
using UnityEngine;

public class CharacterVisuals : MonoBehaviour
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
        CharacterController.instance.OnAttack += CharacterController_OnAttack;
        CharacterStats.instance.OnCharacterDie += InstanceOnOnCharacterDie;
        CharacterStats.instance.OnCharacterRevive += CharacterStats_OnCharacterRevive;
    }
    
    private void Update()
    {
        animator.SetBool(IS_MOVING, CharacterController.instance.IsMoving());
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
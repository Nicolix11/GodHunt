using System;
using UnityEngine;

public class CharacterVisuals : MonoBehaviour
{
    private const string IS_MOVING = "IsMoving";
    private const string ATTACK = "Attack";
    private const string ON_CHARACTER_DIE = "OnCharacterDie";

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CharacterController.instance.OnAttack += CharacterController_OnAttack;
        CharacterStats.instance.OnCharacterDie += CharacterStats_OnCharacterDie;
    }
    
    private void Update()
    {
        animator.SetBool(IS_MOVING, CharacterController.instance.IsMoving());
    }
    
    private void CharacterController_OnAttack(object sender, EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }
    
    private void CharacterStats_OnCharacterDie(object sender, EventArgs e)
    {
        animator.SetTrigger(ON_CHARACTER_DIE);
    }
}
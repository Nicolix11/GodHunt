using System;
using UnityEngine;

public class CharacterVisuals : MonoBehaviour
{
    private const string IS_MOVING = "IsMoving";
    private const string ATTACK = "Attack";

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CharacterController.instance.OnAttack += CharacterController_OnAttack;
    }
    
    private void Update()
    {
        animator.SetBool(IS_MOVING, CharacterController.instance.IsCharacterMoving());
    }
    
    private void CharacterController_OnAttack(object sender, EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }
}

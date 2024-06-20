using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private const string JUMP = "Jump";
    private const string SPEED = "Speed";
    private const string MOVE = "Move";
    private const string THROW = "Throw";

    public PlayerAnimatorController Move(bool value)
    {
        animator.SetBool(MOVE, value);
        return this;
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat(SPEED, speed);
    }

    public void Jump()
    {
        animator.SetTrigger(JUMP);
    }

    public void Throw()
    {
        animator.SetTrigger(THROW);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected const string JUMP = "Jump";
    protected const string SPEED = "Speed";
    protected const string MOVE = "Move";
    protected const string THROW = "Throw";
    protected const string DEATH = "Death";

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
    public virtual void Death()
    {
        animator.Play(DEATH);
    }

}

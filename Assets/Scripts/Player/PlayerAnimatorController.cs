using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    private const string JUMP = "Jump";
    private const string SPEED = "Speed";
    private const string MOVE = "Move";
    private const string THROW = "Throw";
    private const string DEATH = "Death";

    private void Awake()
    {
        HpHandler hpHandler = gameObject.GetComponent<HpHandler>();
        if (hpHandler == null) return;

        hpHandler.Death += Death;
    }

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

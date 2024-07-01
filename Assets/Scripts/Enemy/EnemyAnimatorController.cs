using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : PlayerAnimatorController
{
    public void Revive()
    {
        animator.Play(MOVE);
    }
}

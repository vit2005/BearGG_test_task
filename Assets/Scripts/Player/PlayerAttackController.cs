using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public InputManager InputManager;
    [SerializeField] private PlayerAnimatorController animator;

    void Awake()
    {
        InputManager.Throw += Throw;
    }

    private void Throw()
    {
        animator.Throw();
    }

    public void InstantiateThrowable()
    {
        Debug.Log("Throw");
    }
}

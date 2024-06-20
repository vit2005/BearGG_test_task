using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class PlayerMovingController : MonoBehaviour
{
    public InputManager InputManager;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerAnimatorController animator;

    public const float HORIZONTAL_SPEED_MULTIPLIER = 10f;

    private float horizontalAcceleration;

    void Awake()
    {
        InputManager.Right += Right;
        InputManager.Left += Left;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.forward * horizontalAcceleration, 0.5f);
        animator.SetSpeed(horizontalAcceleration / HORIZONTAL_SPEED_MULTIPLIER);
    }

    private void Right(bool value)
    {
        animator.Move(value || horizontalAcceleration < 0);
        if (value)
        {
            horizontalAcceleration = HORIZONTAL_SPEED_MULTIPLIER;
            transform.eulerAngles = Vector3.zero;
        }
        else if (horizontalAcceleration > 0)
            horizontalAcceleration = 0f;
    }

    private void Left(bool value)
    {
        animator.Move(value || horizontalAcceleration > 0);
        if (value)
        {
            horizontalAcceleration = -HORIZONTAL_SPEED_MULTIPLIER;
            transform.eulerAngles = Vector3.up * 180f;
        }
        else if (horizontalAcceleration < 0)
            horizontalAcceleration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

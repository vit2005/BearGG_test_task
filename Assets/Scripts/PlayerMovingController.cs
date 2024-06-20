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
    public const float JUMP_POWER = 120;
    public const float VERTICAL_SPEED_MODIFIER = 1.4F;

    private float horizontalAcceleration;

    void Awake()
    {
        InputManager.Right += Right;
        InputManager.Left += Left;
        InputManager.Jump += Jump;
    }

    private void FixedUpdate()
    {
        float up = rb.velocity.y;
        if (up < 0) up *= VERTICAL_SPEED_MODIFIER;
        else up /= VERTICAL_SPEED_MODIFIER;
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.forward * horizontalAcceleration + Vector3.up * up, 0.5f);
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

    private void Jump()
    {
        rb.AddForce(Vector3.up * JUMP_POWER, ForceMode.Impulse);
        animator.Jump();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Rendering.Universal;

public class PlayerMovingController : MonoBehaviour
{
    public InputManager InputManager;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerAnimatorController animator;
    [SerializeField] private Transform jumpHandler;

    private PlayerMovementConfig _config;

    private float targetHorizontalSpeed;
    private Vector3 _prevPos;
    private bool _move;
    private float _lastGroundedTime;
    private Coroutine _delayedJump;

    void Awake()
    {
        _config = PlayerMovementConfig.Instance;
        InputManager.Right += Right;
        InputManager.Left += Left;
        InputManager.Jump += Jump;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(jumpHandler.position, Vector3.down, _config.JumpCheckRayLength) || Physics.Raycast(transform.position, Vector3.down, 0.1f))
            _lastGroundedTime = Time.unscaledTime;
        float up = rb.velocity.y;
        if (up < 0) up *= _config.NegativeVerticalSpeedModifier;
        else up /= _config.PositiveVerticalSpeedModifier;

        float horizontalModifier = Mathf.Abs(targetHorizontalSpeed) < 0.001f || 
            Mathf.Sign(targetHorizontalSpeed) != Mathf.Sign(rb.velocity.z) && Mathf.Abs(rb.velocity.x) > 0.001f || 
            Mathf.Abs(rb.velocity.y) > 0.001f ? 
            _config.NegativeHorizontalSpeedModifier : _config.PositiveHorizontalSpeedModifier;
        float horizontalSpeed = Mathf.Lerp(rb.velocity.z, targetHorizontalSpeed, horizontalModifier);
        rb.velocity = Vector3.forward * horizontalSpeed + Vector3.up * up;

        transform.position = new Vector3(0f, transform.position.y, transform.position.z);

        if (_move) animator.Move(Vector3.Distance(_prevPos, transform.position) > 0.001f)
                .SetSpeed(targetHorizontalSpeed / _config.HorizontalMaxSpeed);
        _prevPos = transform.position;
    }

    private void Right(bool value)
    {
        _move = value || targetHorizontalSpeed < 0;
        animator.Move(_move);
        if (value)
        {
            targetHorizontalSpeed = _config.HorizontalMaxSpeed;
            transform.eulerAngles = Vector3.zero;
        }
        else if (targetHorizontalSpeed > 0)
            targetHorizontalSpeed = 0f;
    }

    private void Left(bool value)
    {
        _move = value || targetHorizontalSpeed > 0;
        animator.Move(_move);
        if (value)
        {
            targetHorizontalSpeed = -_config.HorizontalMaxSpeed;
            transform.eulerAngles = Vector3.up * 180f;
        }
        else if (targetHorizontalSpeed < 0)
            targetHorizontalSpeed = 0f;
    }

    private void Jump()
    {
        //if (!characterController.isGrounded) return;
        if ((Time.unscaledTime - _lastGroundedTime) > _config.CoyoteTime)
        {
            if (_delayedJump != null) StopCoroutine(_delayedJump);
            _delayedJump = StartCoroutine(DelayedJump());
            return;
        }

        rb.AddForce(Vector3.up * _config.JumpPower, ForceMode.Impulse);
        animator.Jump();
    }

    private IEnumerator DelayedJump()
    {
        yield return new WaitForSeconds(_config.CoyoteTime);
        if (Mathf.Abs(rb.velocity.y) < 0.001f) Jump();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Action<bool> Right;
    public Action<bool> Left;
    public Action Jump;
    public Action Throw;
    public Action Escape;

    public void RightClick(InputAction.CallbackContext context)
    {
        if (context.started) Right?.Invoke(true);
        if (context.canceled) Right?.Invoke(false);
    }

    public void LeftClick(InputAction.CallbackContext context)
    {
        if (context.started) Left?.Invoke(true);
        if (context.canceled) Left?.Invoke(false);
    }

    public void JumpClick(InputAction.CallbackContext context)
    {
        if (context.started) Jump?.Invoke();
    }

    public void ThrowClick(InputAction.CallbackContext context)
    {
        if (context.started) Throw?.Invoke();
    }

    public void EscapeClick(InputAction.CallbackContext context)
    {
        if (context.started) Escape?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Action<bool> Right;
    public Action<bool> Left;

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
}

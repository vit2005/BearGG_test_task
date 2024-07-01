using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{

    private Collider _target;
    public Action triggered;

    public void Init(Collider target)
    {
        _target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != _target) return;

        triggered?.Invoke();
    }
}

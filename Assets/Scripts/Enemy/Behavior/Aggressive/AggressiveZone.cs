using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveZone : MonoBehaviour
{
    public Action<Transform> entered;
    public Action leaved;
    private int _layer;

    public void Awake()
    {
        _layer = LayerMask.NameToLayer(Layers.PLAYER);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != _layer) return;

        entered?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != _layer) return;

        leaved?.Invoke();
    }
}

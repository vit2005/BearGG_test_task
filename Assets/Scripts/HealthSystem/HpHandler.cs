using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHandler : MonoBehaviour
{
    private int _hp = 100;
    public int HP => _hp;

    public Action Death;

    public void Damage(int value)
    {
        _hp -= value;
        if (_hp <= 0)
        {
            _hp = 0;
            Death?.Invoke();
        }
    }
}

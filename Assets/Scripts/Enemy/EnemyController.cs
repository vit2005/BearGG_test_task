using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected IEnemyBehavior behavior;
    [SerializeField] protected GameObject target;
    protected bool isAlive = true;

    protected virtual void Awake()
    {
        target.GetComponent<HpHandler>().Death += Death;
    }

    protected virtual void Death()
    {
        isAlive = false;
    }

    protected virtual void Update()
    {
        if (isAlive) behavior.OnUpdate();
    }
}

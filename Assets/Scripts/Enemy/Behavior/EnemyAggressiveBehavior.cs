using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggressiveBehavior : IEnemyBehavior
{
    private GameObject _target;

    public EnemyAggressiveBehavior(GameObject target)
    {
        _target = target;
    }

    public void Init(IBehaviorData data)
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}

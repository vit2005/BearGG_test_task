using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrolDataProvider))]
public class PatrolEnemyController : EnemyController
{
    [SerializeField] protected EnemyPatrolDataProvider data;

    protected override void Awake()
    {
        base.Awake();

        var collider = target.GetComponent<Collider>();
        foreach (var item in data.points)
        {
            item.Init(collider);
        }

        behavior = EnemyBehaviorsFactory.GetInstance(target, BehaviorType.Patrol);
        behavior.Init(data);
    }
}

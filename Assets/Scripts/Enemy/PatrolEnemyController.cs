using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrolDataProvider))]
public class PatrolEnemyController : EnemyController
{
    [SerializeField] private EnemyPatrolDataProvider data;
    [SerializeField] private GameObject target;

    private bool isAlive = true;

    private void Awake()
    {
        var collider = target.GetComponent<Collider>();
        foreach (var item in data.points)
        {
            item.Init(collider);
        }

        behavior = EnemyBehaviorsFactory.GetInstance(target, BehaviorType.Patrol);
        behavior.Init(data);

        target.GetComponent<HpHandler>().Death += Death;
    }

    private void Death()
    {
        isAlive = false;
    }

    private void Update()
    {
        if (isAlive) behavior.OnUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrolDataProvider))]
public class PatrolEnemyController : EnemyController
{
    [SerializeField] private EnemyPatrolDataProvider data;
    private void Awake()
    {
        behavior = EnemyBehaviorsFactory.GetInstance(BehaviorType.Patrol);
        behavior.Init();
    }
}

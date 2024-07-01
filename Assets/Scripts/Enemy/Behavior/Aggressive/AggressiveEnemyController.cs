using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class AggressiveEnemyDataProvider : IBehaviorData
{
    public float speed;
    public Transform player;
    public EnemyAnimatorController animator;
}

public class AggressiveEnemyController : PatrolEnemyController
{
    [SerializeField] private AggressiveZone aggressiveZone;
    [SerializeField] private EnemyAnimatorController animator;

    private IEnemyBehavior _patrolBehavior;
    private IEnemyBehavior _aggressiveBehavior;

    protected override void Awake()
    {
        base.Awake();

        _patrolBehavior = behavior;
        _aggressiveBehavior = EnemyBehaviorsFactory.GetInstance(target, BehaviorType.Aggressive);
        aggressiveZone.entered += OnEntered;
        aggressiveZone.leaved += OnLeave;
    }


    private void OnEntered(Transform player)
    {
        var dataAggro = new AggressiveEnemyDataProvider { player = player, speed = data.speed * 2f, animator = animator };
        _aggressiveBehavior.Init(dataAggro);
        behavior = _aggressiveBehavior;
    }
    private void OnLeave()
    {
        behavior = _patrolBehavior;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggressiveBehavior : IEnemyBehavior
{
    private GameObject _target;
    private Transform _player;
    private float _speed;

    public EnemyAggressiveBehavior(GameObject target)
    {
        _target = target;
    }

    public void Init(IBehaviorData data)
    {
        var aggroData = data as AggressiveEnemyDataProvider;
        _player = aggroData.player;
        _speed = aggroData.speed;
        aggroData.animator.SetSpeed(aggroData.speed);
    }

    public void OnRevive()
    {

    }

    public void OnUpdate()
    {
        _target.transform.LookAt(_player);
        _target.transform.eulerAngles = new Vector3(0f, _target.transform.eulerAngles.y, 0f);
        _target.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

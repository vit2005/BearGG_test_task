using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrolBehavior : IEnemyBehavior
{
    private GameObject _target;
    private EnemyPatrolDataProvider _dataProvider;
    private PatrolPoint _currentPoint;
    private float _speed;

    public EnemyPatrolBehavior(GameObject target)
    {
        _target = target;
    }

    public void Init(IBehaviorData data)
    {
        _dataProvider = data as EnemyPatrolDataProvider;
        _currentPoint = _dataProvider.points[0];
        _speed = _dataProvider.speed;
        _currentPoint.triggered += OnTriggered;
    }

    public void OnTriggered()
    {
        _currentPoint.triggered -= OnTriggered;
        _currentPoint = _dataProvider.points.Next(_currentPoint);
        _currentPoint.triggered += OnTriggered;

        _target.transform.LookAt(_currentPoint.transform);
    }

    public void OnRevive()
    {
        _target.transform.localPosition = Vector3.zero;
        _target.transform.LookAt(_currentPoint.transform);
    }

    public void OnUpdate()
    {
        _target.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

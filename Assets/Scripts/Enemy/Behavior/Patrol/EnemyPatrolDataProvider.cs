using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolDataProvider : MonoBehaviour, IBehaviorData
{
    public List<PatrolPoint> points;
    public float speed;
}

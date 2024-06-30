using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BehaviorType
{
    Patrol,
    Aggressive
}

public class EnemyBehaviorsFactory : MonoBehaviour
{
    public static IEnemyBehavior GetInstance(GameObject target, BehaviorType type)
    {
        switch (type)
        {
            case BehaviorType.Patrol:
                return new EnemyPatrolBehavior(target);
            case BehaviorType.Aggressive:
                return new EnemyAggressiveBehavior(target);
            default:
                throw new System.NotImplementedException();
        }
    }
}

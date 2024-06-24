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
    public static IEnemyBehavior GetInstance(BehaviorType type)
    {
        switch (type)
        {
            case BehaviorType.Patrol:
                return new EnemyPatrolBehavior();
            case BehaviorType.Aggressive:
                return new EnemyAggressiveBehavior();
            default:
                throw new System.NotImplementedException();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected IEnemyBehavior behavior;


    private void Update()
    {
        behavior.OnUpdate();
    }
}

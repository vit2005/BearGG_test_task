using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected IEnemyBehavior behavior;
    [SerializeField] protected GameObject target;
    protected bool isAlive = true;
    protected Camera cam;
    protected HpHandler hp;
    protected EnemyDeathHandler deathHandler;
    protected EnemyAnimatorController animator;

    protected virtual void Awake()
    {
        hp = target.GetComponent<HpHandler>();
        hp.Death += Death;
        cam = Camera.main;
        animator = target.GetComponent<EnemyAnimatorController>();
        deathHandler = target.GetComponent<EnemyDeathHandler>();
    }

    protected virtual void Death()
    {
        isAlive = false;
    }

    protected virtual void Revive()
    {
        hp.Revive();
        deathHandler.Revive();
        behavior.OnRevive();
        isAlive = true;
    }

    protected virtual void Update()
    {
        if (isAlive) behavior.OnUpdate();
        else
        {
            Vector3 viewPos = cam.WorldToViewportPoint(target.transform.position);
            bool x = viewPos.x >= -0.5 && viewPos.x <= 1.5;
            bool y = viewPos.y >= -0.5 && viewPos.y <= 1.5;
            bool isVisible = x && y;
            Debug.Log(viewPos + " " + isVisible.ToString());
            if (!isVisible)
            {
                Revive();
            }
        }
    }
}

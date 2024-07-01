using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HpHandler))]
public class EnemyDeathHandler : MonoBehaviour
{
    private Collider targetCollider;
    private EnemyAnimatorController enemyAnimatorController;

    private void Awake()
    {
        targetCollider = GetComponent<Collider>();
        enemyAnimatorController = GetComponent<EnemyAnimatorController>();
        GetComponent<HpHandler>().Death += Death;
    }

    private void Death()
    {
        targetCollider.enabled = false;
        enemyAnimatorController.Death();
        StartCoroutine(DeathProcess());
    }

    public void Revive()
    {
        targetCollider.enabled = true;
        gameObject.SetActive(true);
        enemyAnimatorController.Revive();
    }

    IEnumerator DeathProcess()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public InputManager InputManager;
    [SerializeField] private PlayerAnimatorController animator;
    [SerializeField] private Transform throwAncor;
    [SerializeField] private GameObject fireball;
    int layer;

    void Awake()
    {
        InputManager.Throw += Throw;
        layer = LayerMask.NameToLayer(Layers.ENEMY);
    }

    private void Throw()
    {
        animator.Throw();
    }

    public void InstantiateThrowable()
    {
        var colliders = Physics.OverlapSphere(throwAncor.position, 5f);
        var enemy = colliders.FirstOrDefault(x => x.gameObject.layer == layer);

        Vector3 targetPos = gameObject.GetComponent<Collider>().bounds.center + transform.forward * 5;

        if (enemy != null)
        {
            Vector3 enemyPos = enemy.gameObject.GetComponent<Collider>().bounds.center;
            Vector3 targetDir = enemyPos - throwAncor.position;
            if (Vector3.Dot(targetDir, transform.forward) > 0) targetPos = enemyPos;
        }

        var fireballInstance = Instantiate(fireball, throwAncor.position, Quaternion.identity);
        var rb = fireballInstance.GetComponent<Rigidbody>();
        
        rb.AddForce((targetPos - throwAncor.position) * 4f, ForceMode.Impulse);
    }
}

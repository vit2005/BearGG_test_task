using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    int layer;
    void Awake()
    {
        layer = LayerMask.NameToLayer(Layers.ENEMY);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != layer) return;
        var hpHandler = collision.gameObject.GetComponent<HpHandler>();
        if (hpHandler == null) return;

        hpHandler.Damage(damage);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var hpHandler = other.gameObject.GetComponent<HpHandler>();
        if (hpHandler == null) return;

        hpHandler.Damage(damage);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

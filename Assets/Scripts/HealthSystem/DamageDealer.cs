using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    [SerializeField] bool destroyOnDamage = false;
    [SerializeField] LayerMask layers;

    private void OnTriggerEnter(Collider other)
    {
        if (!Layers.IsLayerInLayerMask(other.gameObject.layer, layers)) return;

        var hpHandler = other.gameObject.GetComponent<HpHandler>();
        if (hpHandler == null) return;

        hpHandler.Damage(damage);
        if (!destroyOnDamage) return;

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForegroundSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> sprites;
    [SerializeField] private Transform parent;
    [SerializeField] private float count;
    [SerializeField] private Vector3 rOffset;
    [SerializeField] private float rScale;
    [SerializeField] private float rRotation;

    
    public List<OrderedSprite> Spawn()
    {
        List<OrderedSprite> spritesList = new();
        foreach (var sprite in sprites)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 position = new Vector3(parent.position.x + rOffset.x * Random.Range(0f, 1f), 0f, parent.position.z + rOffset.z * Random.Range(0f, 1f));
                Quaternion rotation = Quaternion.Euler(0f, 90f, rRotation * Random.Range(0f, 1f));
                var o = Instantiate(sprite, position, rotation, parent);
                o.transform.localScale *= rScale * Random.Range(0.1f, 1f);
                if (Random.Range(0f, 1f) < 0.5f)
                    o.transform.localScale = new Vector3(-o.transform.localScale.x, o.transform.localScale.y, o.transform.localScale.z);
                spritesList.Add(new OrderedSprite { sprite = o.GetComponent<SpriteRenderer>(), distance = position.x });
            }
        }

        return spritesList;
    }
}

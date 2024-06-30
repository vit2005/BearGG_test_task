using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct OrderedSprite
{
    public float distance;
    public SpriteRenderer sprite;
}

public class ForegroundSpawnersManager : MonoBehaviour
{
    private const string SORTING_LAYER = "Forest";
    

    private void Awake()
    {
        List<OrderedSprite> spritesList = new();

        foreach (var spawner in GetComponentsInChildren<ForegroundSpawner>())
        {
            spritesList.AddRange(spawner.Spawn());
        }

        spritesList = new List<OrderedSprite>(spritesList.OrderBy(x => x.distance).ToList());

        for (int i = 0; i < spritesList.Count; i++)
        {
            spritesList[i].sprite.sortingLayerName = SORTING_LAYER;
            spritesList[i].sprite.sortingOrder = i;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers
{
    public const string PLAYER = "Player";
    public const string ENEMY = "Enemy";

    public static bool IsLayerInLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public List<Config> configs;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (var config in configs) { config.Init(); }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class AppController : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

}

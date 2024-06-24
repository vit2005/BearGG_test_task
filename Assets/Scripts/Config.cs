using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Config<T> : ScriptableObject where T : Config<T>
{
    protected static T _instance;
    public static T Instance => _instance;

    public Config() { _instance = (T)this; }
}

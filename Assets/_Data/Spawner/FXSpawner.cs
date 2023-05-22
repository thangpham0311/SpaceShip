using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string Smoke1 = "Smoke_1a";
    public static string Impact1 = "Impact_1";


    protected override void Awake()
    {
        base.Awake();// gọi lên Awake của thằng cha
        if(FXSpawner.instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
        FXSpawner.instance = this;
    }
}

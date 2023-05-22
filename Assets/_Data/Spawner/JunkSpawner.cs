using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner // Dùng để liên kết với meteotiteOne_1
{
    private static JunkSpawner instance;

    public static string meteotiteOne = "meteotite_1";

    public static JunkSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();// gọi lên Awake của thằng cha
        if(JunkSpawner.instance != null) Debug.LogError("Only 1 JunkSpawner allow to exist");
        JunkSpawner.instance = this;
    }
}

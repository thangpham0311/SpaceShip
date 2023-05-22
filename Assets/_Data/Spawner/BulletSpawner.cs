using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;

    public static string BulletOne = "Bullet_1";

    public static BulletSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();// gọi lên Awake của thằng cha
        if(BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner.instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": JunkCtrl", gameObject);
    }

    protected override void Start()
    {
        //this.JunkSpawning();
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RamdomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;


        Transform randPoint = this.junkSpawnerCtrl.SpawnPoints.GetRanDom();
        Vector3 pos = randPoint.position;
        Quaternion ros = transform.rotation;

        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RanDomPrefab();

        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, ros);
        //Transform obj = JunkSpawner.Instance.Spawn(JunkSpawner.meteotiteOne, pos, ros);
        obj.gameObject.SetActive(true);
        //Invoke(nameof(this.JunkSpawning), 2f);
    }

    protected virtual bool RamdomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}

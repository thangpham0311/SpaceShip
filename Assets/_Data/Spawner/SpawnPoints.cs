using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : SaiMonoBehaviour 
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }

    protected virtual void LoadPoint() // dùng để Load tất cả transform để thêm vào List points
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoint", gameObject);
    }

    public virtual Transform GetRanDom() //random ra số với số max là số phần tử trong points
    {
        int random = Random.Range(0, this.points.Count);
        return this.points[random];
    }
}

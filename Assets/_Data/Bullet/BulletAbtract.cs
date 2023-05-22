using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbtract : SaiMonoBehaviour
{
    [Header("Bullet Abtract")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamaReceiver();
    }

    protected virtual void LoadDamaReceiver()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadDamaReceiver", gameObject);
    }
}


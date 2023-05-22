using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpart : BulletAbtract
{
    [Header("Bullet Impart")]

    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.bulletCtrl.DamageSender.Send(other.transform);
        this.CreateImpactFX();
    }

    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFX();

        Vector3 hisPos = transform.position;
        Quaternion hisRot = transform.rotation;

        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hisPos, hisRot * Quaternion.Euler(0f, 0f, 90f));
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.Impact1;
    }
}

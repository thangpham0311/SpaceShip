using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.1f;
    [SerializeField] protected float shootTimer = 0;
    //[SerializeField] protected Transform bulletPrefab;
    //public GameObject bulletPrefab;

    //private void Awake()
    //{
    //    this.bulletPrefab = GameObject.Find("Bullet_1");
    //}
    private void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.IsShooting()) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        //Transform newBullet = Instantiate(this.bulletPrefab,spawnPos, rotation * Quaternion.Euler(0f, 0f, -90f));
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne, spawnPos, rotation * Quaternion.Euler(0f, 0f, -90f));
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1 ;
        return this.isShooting;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JunkFly : parentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(-16,16);
        camPos.z += Random.Range(-16,16);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawLine(objPos, objPos + diff * 7,Color.red,Mathf.Infinity);
    }
}

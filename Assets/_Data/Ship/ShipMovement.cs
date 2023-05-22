using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition; // vị trí mục tiêu của nhân vật
    [SerializeField] protected float speed = 0.01f; // tốc độ di chuyển của nhân vật


    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }
    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos; // chuyển đổi vị trí chuột từ màn hình sang thế giới game
        this.targetPosition.z = 0; // đặt giá trị z của vị trí mục tiêu thành 0 để di chuyển theo mặt phẳng 2D
    }
    protected virtual void LookAtTarget()
    {
        Vector3 direction = targetPosition - transform.parent.position; // tính toán hướng di chuyển của nhân vật
        transform.parent.up = -direction.normalized; // cập nhật hướng nhìn của nhân vật
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);  // di chuyển nhân vật đến vị trí mục tiêu
        transform.parent.position = newPos; // cập nhật vị trí position mới
    }
}

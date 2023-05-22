using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    // xoá viên đạn bằng khoảng cách
    [SerializeField] protected float DisLimit = 70f; // Khoảng các tối đa của viên đạn bay xa khỏi camera
    [SerializeField] protected float distance = 0f; // biến kiểm tra khoảng cách
    [SerializeField] protected Camera mainCam; //vị trí camera
    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera() // hàm này sẽ tự động liên kết với camera mà không phải kéo thủ công trong unity
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>(); // đây là hàm tìm xem Camera để liên kết
    }
    protected override bool CanDespawn()
    {
        // hàm Distance trong vector 3 này để tính khoảng cách giữa vị trí viên đạn và vị trí của camera
        this.distance = Vector3.Distance(transform.position, this.mainCam.transform.position); // Tính khoảng cách từ vị trí của viên đặn tới camera
        if (this.distance > this.DisLimit) return true; // nếu khoảng cách viên đạn lớn hơn khoảng cách cho phép thì trả về true không thì false
        return false;
    }
}

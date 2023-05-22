using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SaiMonoBehaviour // Class này chỉ dùng để Despawn một cái gì đó khi thoả mãn điều kiện Despawn
{
    
    
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning() // kiếm tra xem có thể Despawn không
    {
        if(!this.CanDespawn()) return; 
        this.DespawnObject(); // có thể thì chạy hàm này
    }

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}

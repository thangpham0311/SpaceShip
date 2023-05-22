using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance { get => instance; } 

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManger allow to exist");
       InputManager.instance = this;
    }
    private void FixedUpdate()
    {
        this.GetMouseDown();
        this.GetMousePos();
    }
    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

    public virtual void GetMousePos()
    {
       this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

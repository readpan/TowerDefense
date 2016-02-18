using UnityEngine;
using System.Collections;
using System;

public abstract class Enemy : MonoBehaviour
{
    public float HP;
    public float moveSpeed;
    public Action deadAction;
    public virtual void Awake()
    {
        if (HP == 0)
            HP = 100;
        if (moveSpeed == 0)
            moveSpeed = 5;
        deadAction += Dead;
    }

    public virtual void Dead()
    {
        Destroy(this.gameObject);
    }
}

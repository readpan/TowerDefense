using UnityEngine;
using System.Collections;
using System;

public class EnemyLegacy : EnemyAnimationBase
{
    public Animation anim;
    string ID_Idle;
    string ID_Move;
    string ID_Death;
    public virtual void Awake()
    {
        if (anim == null)
        {
            anim = GetComponent<Animation>();
        }
    }

    public virtual void Start()
    {
        ID_Idle = AnimationStrs.Idle;
        ID_Move = AnimationStrs.Walk;
        ID_Death = AnimationStrs.Death;
        Move(true);
    }

    public override void Death(bool IsDeath)
    {
        throw new NotImplementedException();
    }

    public override void Idle(bool IsIdle)
    {
        if (IsIdle)
        {
            anim.CrossFade(ID_Idle);
            //			animation.CrossFade("Idle");
        }
    }

    public override void Move(bool IsMove)
    {
        if (IsMove)
        {
            anim.CrossFade(ID_Move);
        }
    }
}

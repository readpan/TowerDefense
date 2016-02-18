using UnityEngine;
using System.Collections;
using System;

public class TowerAttackMecanim : TowerAnimationBase
{

    public Animator animator;//动画对象
    //动画
    public static int ID_Idle;
    public static int ID_Attack;

    public virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        //获取参数ID
        ID_Idle = Animator.StringToHash("IsIdle");
        ID_Attack = Animator.StringToHash("IsAttack");
    }

    public virtual void Start()
    {

    }

    public override void Attack(bool IsAttack)
    {
        animator.SetBool(ID_Attack, IsAttack);
    }

    public override void Idle(bool IsIdle)
    {
        animator.SetBool(ID_Idle, IsIdle);
    }
}

//using UnityEngine;
//using System.Collections;
//using System;
///// <summary>
///// 原始动画控制器
///// </summary>
//public class Legacy : AnimationBase
//{

//    public Animation animation;//动画对象

//    const string ID_Idle = "Idle";
//    const string ID_Move = "Walk";
//    const string ID_Attack = "Attack";
//    const string ID_Skill = "Skill";
//    const string ID_Damage = "Damage";
//    const string ID_Death = "Death";

//    const string ID_Run = "Run";
//    const string ID_Jump = "Jump";
//    const string ID_Block = "Block";
//    const string ID_Avoid = "Avoid";
//    const string ID_ComboAttack = "ComboAttack";

//    void Start()
//    {
//        animation = GetComponentInChildren<Animation>();
//    }

//    #region 基础动画：所有模型对象必须都有
//    public override void Idle(bool IsIdle)
//    {
//        if (IsIdle)
//        {
//            animation.CrossFade(ID_Idle);
//            //			animation.CrossFade("Idle");
//        }
//    }

//    public override void Move(bool IsMove)
//    {
//        if (IsMove)
//        {
//            animation.CrossFade(ID_Move);
//            //			animation.CrossFade("Walk");
//        }
//    }

//    public override void Attack(bool IsAttack)
//    {
//        if (IsAttack)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            //			animation[ID_Attack].speed = 1.8f;
//            animation.CrossFade(ID_Attack);

//        }
//    }

//    public override void Skill(bool IsSkill)
//    {
//        if (IsSkill)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Skill);
//        }
//    }

//    public override void Damage(bool IsDamage)
//    {
//        if (IsDamage)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Damage);
//        }
//    }

//    public override void Death(bool IsDeath)
//    {
//        if (IsDeath)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Death);
//        }
//    }

//    public override void Back(bool IsBack)
//    {
//        if (IsBack)
//        {
//            animation.CrossFade(ID_Move);
//        }
//    }
//    #endregion

//    #region 进阶动画：玩家角色专用
//    public override void Run(bool IsRun)
//    {
//        if (IsRun)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Run);
//        }
//    }

//    public override void Jump(bool IsJump)
//    {
//        if (IsJump)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Jump);
//        }
//    }

//    public override void Block(bool IsBlock)
//    {
//        if (IsBlock)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Block);
//        }
//    }

//    public override void Avoid(bool IsAvoid)
//    {
//        if (IsAvoid)
//        {
//            if (animation.isPlaying)
//                animation.Stop();
//            animation.CrossFade(ID_Avoid);
//        }
//    }

//    public override void ComboAttack(int combo)
//    {
//        if (animation.isPlaying)
//            animation.Stop();
//        animation.CrossFade(ID_Attack);
//    }

//    public override void Batter(bool IsBatter)
//    {
//        throw new NotImplementedException();
//    }

//    public override void Sprint(bool IsSprint)
//    {
//        throw new NotImplementedException();
//    }
//    #endregion
//}

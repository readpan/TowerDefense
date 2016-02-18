using UnityEngine;
using System.Collections;
/// <summary>
/// 动画控制抽象父类
/// </summary>
public abstract class AnimationBase : MonoBehaviour {

	#region 基础动画：所有模型对象必须都有
	/// <summary>
	/// 待机
	/// </summary>
	public abstract void Idle(bool IsIdle);
	
	/// <summary>
	/// 走路
	/// </summary>
	public abstract void Move(bool IsMove);
	
	/// <summary>
	/// 攻击
	/// </summary>
	public abstract void Attack(bool IsAttack);
	
	/// <summary>
	/// 施法
	/// </summary>
	public abstract void Skill(bool IsSkill);
	
	/// <summary>
	/// 受伤
	/// </summary>
	public abstract void Damage(bool IsDamage);
	
	/// <summary>
	/// 死亡
	/// </summary>
	public abstract void Death(bool IsDeath);
	#endregion
	
	#region 进阶动画：玩家角色专用
	/// <summary>
	/// 奔跑
	/// </summary>
	public abstract void Run(bool IsRun);
	
	/// <summary>
	/// 跳跃
	/// </summary>
	public abstract void Jump(bool IsJump);
	
	/// <summary>
	/// 格挡
	/// </summary>
	public abstract void Block(bool IsBlock);
	
	/// <summary>
	/// 躲闪
	/// </summary>
	public abstract void Avoid(bool IsAvoid);
	
	/// <summary>
	/// 后退
	/// </summary>
	public abstract void Back(bool IsBack);
	
	/// <summary>
	/// 连击
	/// </summary>
	public abstract void Batter(bool IsBatter);
	#endregion

	/// <summary>
	/// 冲刺
	/// </summary>
	public abstract void Sprint(bool IsSprint);

	
	/// <summary>
	/// 为游戏对象添加动画控制组件
	/// </summary>
	public static AnimationBase AddAnimationBase(Transform character){
		AnimationBase animationBase = null;
		//使用旧的动画系统
//		Animation animation = character.GetComponentInChildren<Animation>();
//		if(animation != null){
//			animationBase = character.gameObject.AddComponent<Legacy>();
//		}else{
			//使用Mecanim动画系统
			Animator animator = character.GetComponentInChildren<Animator>();
			if(animator != null)
				animationBase = character.gameObject.AddComponent<Mecanim>();
//		}
		return animationBase;
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// Mecanim动画控制器
/// </summary>
public class Mecanim : AnimationBase {

	public Animator animator;//动画对象
	
	//基础动画
	public static int ID_Idle;	
	public static int ID_Move;
	public static int ID_Attack;
	public static int ID_Skill;
	public static int ID_Damage;
	public static int ID_Death;
	
	//进阶动画
	public static int ID_Run;
	public static int ID_Jump;
	public static int ID_Block;
	public static int ID_Avoid;
	public static int ID_Batter;
	public static int ID_Back;
	public static int ID_Sprint;
	
	void Start () {
		animator = GetComponentInChildren<Animator>();
//		animator = GetComponent<Animator>();

		//获取参数ID
		ID_Idle = Animator.StringToHash("IsIdle");
		ID_Move = Animator.StringToHash("IsMove");
		ID_Attack = Animator.StringToHash("IsAttack");
		ID_Skill = Animator.StringToHash("IsConjure");
		ID_Damage = Animator.StringToHash("IsDamage");
		ID_Death = Animator.StringToHash("IsDeath");
		
		ID_Run = Animator.StringToHash("IsRun");
		ID_Jump = Animator.StringToHash("IsJump");
		ID_Block = Animator.StringToHash("IsBlock");
		ID_Avoid = Animator.StringToHash("IsAvoid");
		ID_Batter = Animator.StringToHash("IsBatter");
		ID_Back = Animator.StringToHash("IsBack");
		ID_Sprint = Animator.StringToHash("IsSprint");
	}
	
	#region 基础动画：所有模型对象必须都有
	public override void Idle(bool IsIdle){
		animator.SetBool(ID_Idle,IsIdle);
	}
	
	public override void Move(bool IsMove){
//		animator.SetBool(ID_Move,IsMove);
		animator.SetBool("IsMove",IsMove);
	}
	
	public override void Attack(bool IsAttack){
		animator.SetBool(ID_Attack,IsAttack);
//		StartCoroutine(ReboundState(ID_Attack));
	}
	
	public override void Skill(bool IsSkill){
		animator.SetBool(ID_Skill,IsSkill);
		StartCoroutine(ReboundState(ID_Skill));
	}
	
	public override void Damage(bool IsDamage){
		animator.SetBool(ID_Damage,IsDamage);
		StartCoroutine(ReboundState(ID_Damage));
	}
	
	public override void Death(bool IsDeath){
		animator.SetBool(ID_Death,IsDeath);
		StartCoroutine(ReboundState(ID_Death));
	}
	#endregion
	
	#region 进阶动画：玩家角色专用
	public override void Run(bool IsRun){
		animator.SetBool(ID_Run,IsRun);
	}
	
	public override void Jump(bool IsJump){
		animator.SetBool(ID_Jump,IsJump);
	}
	
	public override void Block(bool IsBlock){
		animator.SetBool(ID_Block,IsBlock);
	}
	
	public override void Avoid(bool IsAvoid){
		animator.SetBool(ID_Avoid,IsAvoid);
	}
	
	public override void Batter(bool IsBatter){
		animator.SetBool(ID_Batter,IsBatter);
	} 

	public override void Back(bool IsBack){
		animator.SetBool(ID_Back,IsBack);
	}

	public override void Sprint(bool IsSprint){
		animator.SetBool(ID_Sprint,IsSprint);
		StartCoroutine(ReboundState(ID_Sprint));
	}

	#endregion 
	 
	/// <summary>
	/// 状态归位
	/// </summary>
	IEnumerator ReboundState(int ID){
		yield return new WaitForSeconds(.1f);
		animator.SetBool(ID,false);
	}
	
}

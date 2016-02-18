using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Tower_AttackGun : Tower, IAttack
{
    /// <summary>攻击力</summary>
    public float attackValue;
    /// <summary>攻击范围</summary>
    public float attackRange;
    /// <summary>判定位置</summary>
    public Transform attackCenter;
    /// <summary>攻击频率</summary>
    public float attackRate;
    /// <summary>正在攻击的敌人</summary>
    public List<Enemy> attackingEnemy;
    /// <summary>将敌人打死时调用的</summary>
    public Action deadAction;
    /// <summary>动画系统</summary>
    public TowerAttackMecanim animator;
    /// <summary>模型控制</summary>
    public ControllAttackModelBase controllModel;
    /// <summary>目标层</summary>
    public LayerMask attackLayerMask;
    public override void Awake()
    {
        base.Awake();
        if (attackRange == 0)
            attackRange = 5;
        if (attackCenter == null)
            attackCenter = this.transform;
        if (attackRate == 0)
            attackRate = 1;
        if (attackValue == 0)
            attackValue = 5;
        if (animator == null)
            animator = GetComponent<TowerAttackMecanim>();
        if (controllModel == null)
            controllModel = GetComponent<ControllAttackModelBase>();

        attackLayerMask = LayerMask.GetMask(LayerMasks.Enemy);
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(AttackByRate());
    }

    public override void Update()
    {
        base.Update();
        SearchEnemy();
        //有敌人时候转向敌人
        if (attackingEnemy.Count > 0)
        {
            controllModel.LookAtEnemy(attackingEnemy[0].transform);
        }
    }

    /// <summary>
    /// 攻击
    /// </summary>
    public virtual void Attack()
    {
        attackingEnemy[0].HP -= attackValue;
    }


    /// <summary>
    /// 攻击算法
    /// </summary>
    /// <returns></returns>
    public IEnumerator AttackByRate()
    {
        while (true)
        {
            if (attackingEnemy.Count > 0 && Vector3.Distance(attackCenter.position, attackingEnemy[0].transform.position) <= attackRange)
            {
                animator.Attack(true);
                animator.animator.speed = 1 / attackRate;
                Attack();
                if (attackingEnemy[0].HP <= 0)
                {
                    attackingEnemy[0].deadAction();
                    attackingEnemy.RemoveAt(0);
                }
            }
            else
            {
                animator.Attack(false);
                animator.animator.speed = 1;
            }
            yield return new WaitForSeconds(attackRate);
        }
    }

    /// <summary>
    /// 搜寻敌人
    /// </summary>
    public virtual void SearchEnemy()
    {
        if (attackingEnemy.Count <= 0)
        {
            Collider[] enemy = Physics.OverlapSphere(attackCenter.position, attackRange, attackLayerMask);
            for (int i = 0; i < enemy.Length; i++)
            {
                attackingEnemy.Add(enemy[i].GetComponent<Enemy>());
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public abstract class TowerAnimationBase : MonoBehaviour
{

    #region 基础动画：所有模型对象必须都有
    /// <summary>
    /// 待机
    /// </summary>
    public abstract void Idle(bool IsIdle);

    /// <summary>
    /// 攻击
    /// </summary>
    public abstract void Attack(bool IsAttack);

    #endregion
}

using UnityEngine;
using System.Collections;

public abstract class EnemyAnimationBase : MonoBehaviour
{
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
    /// 死亡
    /// </summary>
    public abstract void Death(bool IsDeath);
    #endregion

}

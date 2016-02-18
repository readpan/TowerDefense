using UnityEngine;
using System.Collections;

public abstract class ControllAttackModelBase : ControllModelBase
{
    /// <summary>
    /// 旋转时控制的地方
    /// </summary>
    public Transform rotatePlace;
    /// <summary>
    /// 攻击时候看着敌人
    /// </summary>
    public abstract void LookAtEnemy(Transform target);
}

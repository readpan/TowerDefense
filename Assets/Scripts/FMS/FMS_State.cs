using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class FMS_State
{
    public TowerStateID StateID;
    private Dictionary<TowerActionConditions, TowerStateID> map = new Dictionary<TowerActionConditions, TowerStateID>();
    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="tac"></param>
    /// <param name="ID"></param>
    public void AddDictionary(TowerActionConditions tac, TowerStateID ID)
    {
        if (tac == TowerActionConditions.NullActionCondition)
        {
            Debug.LogError("None Condition can not be added.Please check the TowerActionCondition you has added !");
            return;
        }
        if (ID == TowerStateID.NullStateID)
        {
            Debug.LogError("None StateID can not be added.Please check the StateID you has added !");
            return;
        }
        if (map.ContainsKey(tac))
        {
            Debug.LogError(tac + "has already added !");
            return;
        }
        map.Add(tac, ID);
    }
    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="tac"></param>
    public void DeleteDictionary(TowerActionConditions tac) //删除字典里存储的一个状态
    {
        if (tac == TowerActionConditions.NullActionCondition)
        {
            Debug.LogError("TransNull is not allowed to delate");
            return;
        }
        if (map.ContainsKey(tac))
        {

            map.Remove(tac);
            return;
        }
        Debug.LogError(tac.ToString() + "are not exist");
    }
    public TowerStateID GetOutState(TowerActionConditions tac)
    {
        if (map.ContainsKey(tac))
        {
            return map[tac];
        }
        return TowerStateID.NullStateID;
    }

    public virtual void DoBeforeEnter() { }    //虚方法
    public virtual void DoBeforeMoveing() { }
    public abstract void Reason(GameObject tower, GameObject enemy);
    public abstract void Act(GameObject tower, GameObject enemy);
}

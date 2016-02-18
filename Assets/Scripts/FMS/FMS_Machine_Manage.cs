using UnityEngine;
using System.Collections.Generic;
using DevelopEngine;

public class FMS_Machine_Manage : MonoSingleton<FMS_Machine_Manage>
{
    private List<FMS_State> states;//存储所有状态的的List
    public FMS_State currentState; //当前状态
    public TowerStateID currentStateID;

    public GameObject tower;

    public void Awake()
    {
        states = new List<FMS_State>();
    }
    
    /// <summary>
    /// 初始化状态机
    /// </summary>
    public void MakeFMSMachine()
    {
        Attack_State attack = new Attack_State();
        attack.AddDictionary(TowerActionConditions.SeeEnemy, TowerStateID.AttackEnemy);

        Instance.AddFMSState(attack);


    }
    /// <summary>
    /// 注册状态
    /// </summary>
    /// <param name="s"></param>
    public void AddFMSState(FMS_State s)
    {
        if (s == null)
        {
            Debug.LogError(" Null reference is not allowed");
        }

        if (states.Count == 0)
        {
            states.Add(s);                   //设置默认状态（important）;
            currentState = s;
            currentStateID = s.StateID;
            return;
        }
        foreach (FMS_State state in states)
        {
            if (state == s)
            {
                Debug.LogError(s.StateID.ToString() + "has already been added");
                return;
            }
        }
        states.Add(s);
    }
    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="id"></param>
    public void DeleteFmsState(TowerStateID id)
    {
        if (id == TowerStateID.NullStateID)
        {

            Debug.LogError("NullStateID is not allowed for a real state");

            return;
        }

        foreach (FMS_State state in states)
        {

            if (state.StateID == id)
            {
                states.Remove(state);
                return;
            }

        }
    }

    public void changeState(TowerActionConditions tac)           //更改状态
    {
        if (tac == TowerActionConditions.NullActionCondition)
        {
            Debug.LogError("NullTransition is not allowed for a real transition");
            return;
        }
       
        TowerStateID id = currentState.GetOutState(tac);   //当前状态会进入的新的状态
        currentStateID = id;

        //    Debug.Log("Prives" + Prives.ID);
        foreach (FMS_State state in states)          //通过注册的所有状态，进行搜索来获取要进入的状态实例
        {
            if (currentStateID == state.StateID)
            {
                currentState.DoBeforeMoveing();     //退出状态前，留下点什么，比如挥舞下手臂
                currentState = state;
                currentState.DoBeforeEnter();     //进入状态
                break;
            }
        }
    }
}

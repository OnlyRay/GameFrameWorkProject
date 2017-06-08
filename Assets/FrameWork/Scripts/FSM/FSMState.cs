using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态之间转换的条件
public enum Transition
{
    NullTransition = 0,
    SawPlayer,//发现主角
    LostPlayer//跟丢主角
}
//每个状态的唯一标识
public enum StateID
{
    NullStateID = 0,
    Partrol,//巡逻状态
    Chase//追逐主角状态

}

public abstract class FSMState {
    //每个状体共有的
    protected StateID stateID;
    public StateID GetStateID
    {
        get
        {
            return stateID;
        }
    }
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();
    public FSMSystem fsm;

    public void AddTransition(Transition trans,StateID id)//状体转换的条件的增加
    {
        if(trans == Transition.NullTransition || id == StateID.NullStateID)
        {
            Debug.LogError("Transition or StateID is not exited!!");
        }

        if(map.ContainsKey(trans))
        {
            Debug.LogError("The state: " + id + "already has ites transition" + trans);
            return;
        }

        map.Add(trans, id);
    }

    public void DeleteTransition(Transition trans)//状体转换的条件的删除
    {
        if (map.ContainsKey(trans) == false)
        {
            Debug.LogWarning("The Transition " + trans + "you want to delete is not exited in the map");
        }

        map.Remove(trans);
    }

    public StateID GetOutputState(Transition trans)
    {
        //根据转换的状体条件看是否能够发生转换
        //如果能够发生转换，就转换到对应的ID，否则就是空的ID
        if(map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    //在进入当前状态之前做的事情
    public virtual void DoBeforeEntering()
    {

    }

    //在进入当前状态之前做的事情
    public virtual void DoBeforeLeaving()
    {

    }

    public abstract void DoUpdate();//在状态机处于当前状态的时候会一直调用
}

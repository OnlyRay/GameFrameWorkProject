using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//有限状态机系统类（管理）
public class FSMSystem : MonoBehaviour {
    //保存当前状态机有哪些状态
    private Dictionary<StateID, FSMState> states;
    //当前状态机处于什么状态
    private FSMState currentState;

    public FSMState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public FSMSystem()
    {
        states = new Dictionary<StateID, FSMState>();
    }
	
    //往状态机里添加状态
    public void AddState(FSMState state)
    {
        if(state == null)
        {
            Debug.LogError("The state you want to add is null");
            return;
        }
        if(states.ContainsKey(state.GetStateID))
        {
            Debug.LogError("The state:" + state.GetStateID + "you want to add has already been added.");
        }
        state.fsm = this;
        states.Add(state.GetStateID, state);
    }
    //往状态机里删除状态
    public void DeleteState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("The state you delete to add is null");
            return;
        }
        if (states.ContainsKey(state.GetStateID) == false)
        {
            Debug.LogError("The state:" + state.GetStateID + "you want to delete is not exited.");
        }

        states.Remove(state.GetStateID);
    }

    public void PerformTransition(Transition trans)
    {//当发生一个条件，按照这个条件进行转换
        if(trans == Transition.NullTransition)
        {
            Debug.LogError("NullTransition is not allowed for a real transition.");
        }

        StateID id = currentState.GetOutputState(trans);
        if(id == StateID.NullStateID)
        {
            Debug.LogWarning("Transition is not to be happened");
            return;
        }
        //得到了合适的要转换的目标状态的ID
        FSMState state;
        states.TryGetValue(id, out state);
        currentState.DoBeforeLeaving();
        currentState = state;
        currentState.DoBeforeEntering();
    }

    public void StartFSM(StateID id)//用来启动状态机,设置默认状态
    {
        FSMState state;
        bool isGet = states.TryGetValue(id, out state);
        if(isGet)
        {
            state.DoBeforeEntering();
            currentState = state;
        }
        else
        {
            Debug.LogError("The state " + id + " is not exited in the fsm");
        }
    }
}

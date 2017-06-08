using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour {

    private FSMSystem fsm;
    public Transform[] wayPoints;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }
	
	void InitFSM()//初始化状态机
    {
        fsm = new FSMSystem();

        PatrolState patrolState = new PatrolState(wayPoints,this.gameObject,player);
        patrolState.AddTransition(Transition.SawPlayer, StateID.Chase);
        ChaseState chaseState = new ChaseState(this.gameObject,player);
        chaseState.AddTransition(Transition.LostPlayer, StateID.Partrol);

        fsm.AddState(patrolState);
        fsm.AddState(chaseState);

        fsm.StartFSM(StateID.Partrol);//默认是巡逻状态
    }

    void Update()
    {
        fsm.CurrentState.DoUpdate();
    }
}

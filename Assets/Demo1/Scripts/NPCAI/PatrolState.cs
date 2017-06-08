using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState {
    private int TargetWayPoint;
    private Transform[] wayPonits;
    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;
	public PatrolState(Transform[] wp,GameObject npc,GameObject player)
    {
        stateID = StateID.Partrol;
        wayPonits = wp;
        this.npc = npc;
        TargetWayPoint = 0;//从数组零号开始运动 
        npcRd = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering State" + GetStateID);
    }
    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }
    //检查转换条件
    private void CheckTransition()
    {
        if(Vector3.Distance(player.transform.position,npc.transform.position)<5)
        {
            fsm.PerformTransition(Transition.SawPlayer);
        }
    }

    private void PatrolMove()//巡逻移动
    {
        npcRd.velocity = npc.transform.forward * 10;
        Transform targetTrans = wayPonits[TargetWayPoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            TargetWayPoint++;
            TargetWayPoint %= wayPonits.Length;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState {

    private GameObject npc;
    private Rigidbody npcRd;
    private GameObject player;

	public ChaseState(GameObject npc, GameObject player)
    {
        stateID = StateID.Chase;
        this.npc = npc;
        npcRd = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering State" + GetStateID);
    }

    public override void DoUpdate()
    {
        ChaseMove();
    }

    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) >20)
        {
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }

    private void ChaseMove()
    {
        npcRd.velocity = npc.transform.forward * 3;
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
    }
}


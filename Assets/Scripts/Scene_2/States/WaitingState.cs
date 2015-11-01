using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : NPCState
{
	public WaitingState(GameObject player, GameObject npc) 
	{
		base.player = player;
		base.npc = npc;
		stateID = StateID.WaitingStateID;
	}
	
	public override void TransitionCondition()
	{
		if (npc.GetComponent<NPCController>().getAllItems())
			npc.GetComponent<NPCController>().SetTransition(Transition.PlayerTaskComplete);
	}
	
	public override void StateUpdate()
	{
		npc.GetComponent<NPCController> ().followRoutine();
		npc.GetComponent<NPCController> ().manageDialogue();
	}

	public override void OnStateEntered ()
	{
		base.OnStateEntered ();		
		npc.GetComponent<Collider> ().enabled = false;
		Debug.Log ("Enter WaitingState");
	}
	
	public override void OnStateExit ()
	{
		base.OnStateExit ();
		Debug.Log ("Exit WaitingState");
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveState : NPCState
{
	public InteractiveState(GameObject player, GameObject npc) 
	{
		base.player = player;
		base.npc = npc;
		stateID = StateID.InteractiveStateID;
	}
		
	public override void TransitionCondition()
	{
		if (npc.GetComponent<NPCController>().getTaskSet())
			npc.GetComponent<NPCController>().SetTransition(Transition.SetPlayerTask);
	}
		
	public override void StateUpdate()
	{
		npc.GetComponent<NPCController> ().trackPlayer();
		npc.GetComponent<NPCController> ().manageDialogue();
	}

	public override void OnStateEntered ()
	{
		base.OnStateEntered ();
		npc.GetComponent<Collider> ().enabled = true;
		Debug.Log ("Entered InteractiveState");
	}
		
	public override void OnStateExit ()
	{
		base.OnStateExit ();
		Debug.Log("Exit InteractiveState");
	}
}
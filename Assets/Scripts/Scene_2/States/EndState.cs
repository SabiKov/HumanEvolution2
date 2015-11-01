using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : NPCState
{
	public EndState(GameObject player, GameObject npc) 
	{
		base.player = player;
		base.npc = npc;
		stateID = StateID.EndStateID;
	}

	public override void TransitionCondition()
	{
		if (npc.GetComponent<NPCController>().getFinished())
			npc.GetComponent<NPCController>().SetTransition(Transition.AllDone);
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
		Debug.Log ("Enter EndState");
	}
	
	public override void OnStateExit ()
	{
		base.OnStateExit ();
		Debug.Log ("Exit EndState");
	}
}


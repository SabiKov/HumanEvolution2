using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : NPCState
{
	PlayerScene2 playerScript;
	NPCController npcScript;

	public WaitingState(GameObject player, GameObject npc) 
	{
		base.player = player;
		base.npc = npc;
		playerScript = player.GetComponent<PlayerScene2>();
		npcScript = npc.GetComponent<NPCController>();
		stateID = StateID.WaitingStateID;
	}
	
	public override void TransitionCondition()
	{
		if (playerScript.PlayerHasQuestItem(npcScript.QuestItem()))
			npcScript.SetTransition(Transition.PlayerTaskComplete);
	}
	
	public override void StateUpdate()
	{
		npc.GetComponent<NPCController> ().FollowRoutine();
		npc.GetComponent<NPCController> ().ManageDialogue();
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
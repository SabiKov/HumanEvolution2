using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineState : NPCState
{
	private int currentWayPoint;
	private Transform[] waypoints;
	

	public RoutineState()
	{
		// Empty Constructor for testing
		stateID = StateID.RoutineStateID;
	}

	public RoutineState(GameObject player, GameObject npc) 
	{
		base.player = player;
		base.npc = npc;
		stateID = StateID.RoutineStateID;
	}
	
	public override void TransitionCondition()
	{
		if(!GameObject.Find ("Infopoint") && !player.GetComponent<PlayerScene2> ().taskCompleted)
		{
			npc.GetComponent<NPCController>().SetTransition(Transition.PlayerLearning);
		}
	}
	
	public override void StateUpdate()
	{
		npc.GetComponent<NPCController> ().FollowRoutine ();
	}
	
	public override void OnStateEntered ()
	{
		base.OnStateEntered ();
		npc.GetComponent<Collider> ().enabled = false;
		Debug.Log ("Enter RoutineState");
	}
	
	public override void OnStateExit ()
	{
		base.OnStateExit ();
		Debug.Log ("Exit RoutineState");
	}
}
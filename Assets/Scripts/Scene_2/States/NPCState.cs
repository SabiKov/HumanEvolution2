using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCState
{
	protected Dictionary<Transition, StateID> transitionMap = new Dictionary<Transition, StateID>();
	protected StateID stateID;
	public StateID ID { get { return stateID; } }
	private NPCState currentState;
	public NPCState CurrentState { get { return currentState; } }
	protected GameObject player, npc;
	
	public void AddTransition(Transition transition, StateID id)
	{
		if (transition == Transition.NullTransition)
		{
			Debug.LogError("NPCState AddTransition(): NullTransition is not allowed for a real transition");
			return;
		}
		
		if (id == StateID.NullStateID)
		{
			Debug.LogError("NPCState AddTransition(): NullStateID is not allowed for a real ID");
			return;
		}
		
		if (transitionMap.ContainsKey(transition))
		{
			Debug.LogError("NPCState AddTransition(): " + stateID.ToString() + " already has transition " + 
			               transition.ToString());
			return;
		}
		
		transitionMap.Add(transition, id);
	}
	
	public void DeleteTransition(Transition transition)
	{
		if (transition == Transition.NullTransition)
		{
			Debug.LogError("NPCState DeleteTransition(): NullTransition is not allowed");
			return;
		}
		
		if (transitionMap.ContainsKey(transition))
		{
			transitionMap.Remove(transition);
			return;
		}
		Debug.LogError("NPCState DeleteTransition(): " + transition.ToString() + " is not on " + 
		               stateID.ToString() + " transition list");
	}
	
	public StateID GetOutputState(Transition transition)
	{
		if (transitionMap.ContainsKey(transition))
		{
			return transitionMap[transition];
		}
		return StateID.NullStateID;
	}
	
	public virtual void OnStateEntered() { }
	
	public virtual void OnStateExit() { } 
	
	public abstract void TransitionCondition();
	
	public abstract void StateUpdate();
}
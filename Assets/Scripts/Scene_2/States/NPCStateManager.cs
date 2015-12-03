using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateManager
{
	private List<NPCState> states;
	
	private StateID currentStateID;
	public StateID CurrentStateID { get { return currentStateID; } }
	private NPCState currentState;
	public NPCState CurrentState { get { return currentState; } }
	
	public NPCStateManager()
	{
		states = new List<NPCState>();
	}
	
	public void AddState(NPCState newState)
	{
		if (newState == null)
		{
			Debug.LogError("StateManager AddState(): Null state");
		}
		
		if (states.Count == 0)
		{
			states.Add(newState);
			currentState = newState;
			currentStateID = newState.ID;
			return;
		}
		
		foreach (NPCState state in states)
		{
			if (state.ID == newState.ID)
			{
				Debug.LogError("StateManager AddState(): " + newState.ID.ToString() + " already exists");
				return;
			}
		}
		states.Add(newState);
	}
	
	public void DeleteState(StateID id)
	{
		if (id == StateID.NullStateID)
		{
			Debug.LogError("StateManager DeleteState(): NullStateID!");
			return;
		}
		
		foreach (NPCState state in states)
		{
			if (state.ID == id)
			{
				states.Remove(state);
				return;
			}
		}
		Debug.LogError("StateManager DeleteState(): " + id.ToString() + " not in list");
	}
	
	public void PerformTransition(Transition transition)
	{
		if (transition == Transition.NullTransition)
		{
			Debug.LogError("StateManager PerformTransition(): NullTransition not allowed");
			return;
		}
		
		StateID id = currentState.GetOutputState(transition);
		if (id == StateID.NullStateID)
		{
			Debug.LogError("StateManager PerformTransition(): " + currentStateID.ToString() +
			               " does not have a next state for transition " + transition.ToString());
			return;
		}
		
		currentStateID = id;
		foreach (NPCState state in states)
		{
			if (state.ID == currentStateID)
			{
				currentState.OnStateExit();
				
				currentState = state;
				
				currentState.OnStateEntered();
				break;
			}
		}
		
	}	

	public List<NPCState> CurrentManagerStates()
	{
		return states;
	}
	
	public bool CheckForState(NPCState inList)
	{
		foreach (NPCState state in states)
		{
			if (state == inList)
			{
				return true;
			}
		}
		return false;
	}
}
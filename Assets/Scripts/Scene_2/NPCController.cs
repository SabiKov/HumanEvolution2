/*
 * This is my basic NPCController, 
 * should be amenable to most task-driven NPCs
 * 
 * */

using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Needed for waypoint navigtion
public class NPCController : MonoBehaviour
{
	private NPCStateManager manager;
	public GameObject player, popup, dialogue, thanks;
	public Transform[] path;
	int currentPath;
	protected bool taskSet, offer, talking, contact, finished, allItems, learning;
	public string questItem;
	public string questTopic;
	
	public void SetTransition(Transition transition) { manager.PerformTransition(transition); }
	
	public void Start()
	{
		currentPath = 0;
		MakeStateManager();
	}
	
	public void FixedUpdate()
	{
		manager.CurrentState.TransitionCondition();
		manager.CurrentState.StateUpdate();
	}
	
	private void MakeStateManager()
	{
		RoutineState routine = new RoutineState(player, gameObject);
		routine.AddTransition(Transition.PlayerLearning, StateID.InteractiveStateID);
		
		InteractiveState interactive = new InteractiveState(player, gameObject);
		interactive.AddTransition(Transition.SetPlayerTask, StateID.WaitingStateID);
		
		WaitingState waiting = new WaitingState(player, gameObject);
		waiting.AddTransition(Transition.PlayerTaskComplete, StateID.EndStateID);

		EndState end = new EndState(player, gameObject);
		end.AddTransition(Transition.AllDone, StateID.RoutineStateID);
		
		manager = new NPCStateManager();
		manager.AddState(routine);
		manager.AddState(interactive);
		manager.AddState(waiting);
		manager.AddState(end);
	}

	public void Update()
	{		

	}

	private void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			/*if(player.GetComponent<PlayerScene2>().CheckWhatPlayerLearned(questTopic))
			{
				SetLearning(true);
			}*/
			contact = true;
		}
	}
	
	private void OnTriggerStay(Collider c)
	{
		if(Input.GetKeyUp(KeyCode.X))
		{
			if(talking)
				talking = false;
			else
				talking = true;
		}
	}
	
	private void OnTriggerExit(Collider c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			contact = false;
		}		
	}

	public void FollowRoutine ()
	{
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		Vector3 moveDir = path[currentPath].position - transform.position;
		
		if (moveDir.magnitude < 1)
		{
			currentPath++;
			if (currentPath >= path.Length)
			{
				currentPath = 0;
			}
		}
		else
		{
			vel = moveDir.normalized;
			
			transform.rotation = Quaternion.Slerp(transform.rotation,
			                                          Quaternion.LookRotation(moveDir),
			                                          5 * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
			
		}
		GetComponent<Rigidbody>().velocity = vel;
	}
	
	public void TrackPlayer()
	{
		Vector3 playerPosition = 
			new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
		transform.LookAt(playerPosition);
	}

	public void ManageDialogue()
	{
		if(contact)
		{
			if (talking)
			{
				if (allItems)
				{
					thanks.SetActive(true);
				}
				else
				{
					thanks.SetActive(false);
					dialogue.SetActive(true);
				}
			}
			else
			{
				dialogue.SetActive(false);
				popup.SetActive(true);
			}
		}
		else
		{
			popup.SetActive(false);
		}
	}

	public void PlayerHelping(bool helping)
	{
		talking = false;
		ManageDialogue ();
		contact = false;
		ManageDialogue ();
		taskSet = helping;
	}

	public bool GetTaskSet()
	{
		return taskSet;
	}

	public void SetTaskSet(bool set)
	{
		taskSet = set;
	}

	public void SetFinished(bool finished)
	{
		this.finished = finished;
		thanks.SetActive(false);
		popup.SetActive(false);
	}

	public bool GetFinished()
	{
		return finished;
	}

	public string QuestItem()
	{
		return questItem;
	}

	public bool GetLearning()
	{
		return learning;
	}
	
	public void SetLearning(bool set)
	{
		taskSet = set;
	}

}

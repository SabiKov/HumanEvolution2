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
	public GameObject player, item_1, item_2, item_3, popup, dialogue, thanks;
	public Transform[] path;
	int currentPath;
	protected bool taskSet, offer, talking, contact, finished, allItems;
	
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
		string tag = c.tag;
		
		if("Player" == tag)
		{
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
		string tag = c.tag;
		
		if("Player" == tag)
		{
			contact = false;
		}		
	}

	public void followRoutine ()
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
	
	public void trackPlayer()
	{
		Vector3 playerPosition = 
			new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
		transform.LookAt(playerPosition);
	}

	public void manageDialogue()
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
	
	public void setUpTask()
	{
		item_1.GetComponent<MeshRenderer>().enabled = true;
		item_1.GetComponent<Collider>().enabled = true;
		item_2.GetComponent<MeshRenderer>().enabled = true;
		item_2.GetComponent<Collider>().enabled = true;
		item_3.GetComponent<MeshRenderer>().enabled = true;
		item_3.GetComponent<Collider>().enabled = true;
	}

	public void playerHelping(bool helping)
	{
		talking = false;
		manageDialogue ();
		setUpTask ();
		contact = false;
		manageDialogue ();
		taskSet = helping;
	}

	public bool getTaskSet()
	{
		return taskSet;
	}

	public void setTaskSet(bool set)
	{
		taskSet = set;
	}

	public bool getAllItems()
	{
		if (player.GetComponent<PlayerScene2> ().getItems () > 2)
		{
			allItems = true;
			return allItems;
		}
		else
			return false;
	}

	public void setFinished(bool finished)
	{
		this.finished = finished;
		thanks.SetActive(false);
		popup.SetActive(false);
	}

	public bool getFinished()
	{
		return finished;
	}
}

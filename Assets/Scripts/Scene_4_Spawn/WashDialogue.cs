using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;

public class WashDialogue : MonoBehaviour {

	FirstPersonController firstPerson;
	bool dirtyPlayer, playerAtPond;
	//A variable to hold thre time value during dialogue game-stop
	private float savedTimeScale;

	// Use this for initialization
	void Start () {
		dirtyPlayer = true;
		playerAtPond = false;
	}


	// Update is called once per frame
	void Update () {
	}
	

	/**
	 * Called when the player character comes into the 'zone'
	 * of the city pond
	 */
	void OnTriggerEnter(Collider colide)
	{		
		
		if (colide.gameObject.tag == "Player")
		{
			playerAtPond = true;

			//freeze mouse-look
			firstPerson = colide.gameObject.GetComponent<FirstPersonController> ();
			firstPerson.setInDialogueToggle();

			colide.gameObject.GetComponent<FirstPersonController> ().setInDialogueToggle();		
			Debug.Log("player at pond");

		}
	}

	/**
	 * Called when the player character leaves the 'zone'
	 * of the city pond
	 */
	void OnTriggerExit(Collider colide)
	{				
		if (colide.gameObject.tag == "Player")
		{
			//un-freeze mouse-look
			colide.gameObject.GetComponent<FirstPersonController> ().setInDialogueToggle();			
			Debug.Log("player leaves pond");
			playerAtPond = false;

		}
	}



	void OnGUI () {
		//Display the Dialog.
		if(playerAtPond){

			//PauseGame();
			if(dirtyPlayer){

				//PauseGame();

				//Build the little on-screen dialogue box
				GUI.BeginGroup(new Rect(Screen.width/4, (Screen.height/3)*2, Screen.width/2, Screen.height/3));
				GUI.Box(new Rect(0, 0, 400, 300), "You come across an ornamental pond\n Would you like to wash up ?\n You ARE a little dirty after all the adventuring");
				GUI.EndGroup();
				
				///GUI.Label(new Rect (40, 200, 350, 120), NPCTalk[myIndex]);
				GUI.Label(new Rect (250, 470, 300, 120), "Would you like To wash ?");
				
				if (GUI.Button(new Rect(250,530,300,25), "Yes Please"))
				{
					//UnPauseGame();
					dirtyPlayer = false;
					firstPerson.washPlayer();
				}
				
				if (GUI.Button(new Rect(250,570,300,25), "No Way!"))
				{
					//UnPauseGame();
				}

			}

		}
	}



	// ***************************************
	void PauseGame()
	{
		//capture current time
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}
	
	void UnPauseGame() 
	{
		//re-start time
		Time.timeScale = savedTimeScale;
	}


}

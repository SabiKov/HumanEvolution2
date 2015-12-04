using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;

public class NPCDialogue_busy2 : MonoBehaviour {

	FirstPersonController firstPerson;
	
	//String arrays to hold dialogue info
	String[] NPCTalk = new String[4];
	String[] PCTalk = new String[4];
	int myIndex = 0;
	
	//A variable to hold thre time value during dialogue game-stop
	private float savedTimeScale;
	
	//A boolean to switch mouse-movement in fpc-Camera during dialogue
	bool myTalking = false;
	GameObject firstPersonControllerCamera;
	
	
	void Start()
	{
		//Initialize conversation values.
		//must be the same length each for this simple dialogue exchange
		NPCTalk[0] = "What do you want, ruffian";
		NPCTalk[1] = "I don't talk to scruffy vagrants";
		NPCTalk[2] = "I only converse with clean people";
		NPCTalk[3] = "";
		
		
		PCTalk[0] = "I wonder if you can help..";
		PCTalk[1] = "Please .. have you seen a book..";
		PCTalk[2] = "I must need to wash-up then hmm..";
		PCTalk [3] = "";
	}
	
	
	void OnGUI () {
		//Display the Dialog.
		if(myTalking){
			
			//Build the little on-screen dialogue box
			GUI.BeginGroup(new Rect(Screen.width/4, (Screen.height/3)*2, Screen.width/2, Screen.height/3));
			GUI.Box(new Rect(0, 0, 400, 300), "You strike up a conversation\n with a busy pedestrian");
			GUI.EndGroup();
			
			///GUI.Label(new Rect (40, 200, 350, 120), NPCTalk[myIndex]);
			GUI.Label(new Rect (250, 470, 300, 120), NPCTalk[myIndex]);
			
			if (GUI.Button(new Rect(250,514,300,25), PCTalk[myIndex]))
			{
				if(myIndex >= (PCTalk.Length)-1)
				{
					myIndex = (PCTalk.Length)-1;
				}
				else
				{
					myIndex++;
				}	
			}
			
			
			if (GUI.Button(new Rect(325,542,150,25),"Start Over."))
			{
				myIndex = 0;
			}
			
			if (GUI.Button(new Rect(250,570,300,25), "Goodbye!"))
			{
				//myTalking = false;
				UnPauseGame ();
			}
		}
	}
	
	/**
	 * Called when the player character comes into the 'zone'
	 * of an npc with a talk dialogue
	 */
	void OnTriggerEnter(Collider colide)
	{		
		
		if (colide.gameObject.tag == "Player")
		{
			//freeze mouse-look
			firstPerson = colide.gameObject.GetComponent<FirstPersonController> ();
			firstPerson.setInDialogueToggle();

			if(firstPerson.isPlayerDirty()){
				//Initialize conversation values.
				//must be the same length each for this simple dialogue exchange
				NPCTalk[0] = "What do you want, ruffian";
				NPCTalk[1] = "I don't talk to scruffy vagrants";
				NPCTalk[2] = "I only converse with clean people";
				NPCTalk[3] = "";
					
				PCTalk[0] = "I wonder if you can help..";
				PCTalk[1] = "Please .. have you seen a book..";
				PCTalk[2] = "I must need to wash-up then hmm..";
				PCTalk [3] = "";
			}
			else{
				NPCTalk[0] = "Ah you have cleaned yourself up";
				NPCTalk[1] = "So what was it you wanted";
				NPCTalk[2] = "I think i saw one near the gallery";
				NPCTalk[3] = "";

				PCTalk[0] = "Yes I feel better now";
				PCTalk[1] = "im looking for an old book..";
				PCTalk[2] = "OK thank you";
				PCTalk [3] = "";
			}
			
			Debug.Log("met player");
			myTalking = true;
			PauseGame ();
		}
	}
	/**
	 * Called when the player character leaves the 'zone'
	 * of an npc with a talk dialogue
	 */
	void OnTriggerExit(Collider colide)
	{		
		
		if (colide.gameObject.tag == "Player")
		{
			//un-freeze mouse-look
			colide.gameObject.GetComponent<FirstPersonController> ().setInDialogueToggle();
			
			Debug.Log("Bye bye player");
			myTalking = false;
			UnPauseGame ();
		}
	}
	
	// ***************************************
	
	
	void PauseGame()
	{
		//capture current time
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
	}
	
	void UnPauseGame() 
	{
		//re-start time
		Time.timeScale = savedTimeScale;
		AudioListener.pause = false;
	}
	
}




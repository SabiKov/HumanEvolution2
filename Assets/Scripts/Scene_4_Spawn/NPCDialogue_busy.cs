using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;

public class NPCDialogue_busy : MonoBehaviour {
	
	//String arrays to hold dialogue info
	String[] NPCTalk = new String[7];
	String[] PCTalk = new String[7];
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
		NPCTalk[1] = "Can I help you";
		NPCTalk[2] = "No i'v no where to rush off too, unlike everyone else";
		NPCTalk[3] = "Actually I'm out of work at the moment";
		NPCTalk[4] = "I'm an electrician. A good one";
		NPCTalk[5] = "No problem. It'll cost you though";
		NPCTalk[6] = "10 euro should be enough";
		
		PCTalk[0] = "Hi";
		PCTalk[1] = "You aren't rushing around like everyone else?";
		PCTalk[2] = "Why's that then.";
		PCTalk[3] = "Thats too bad. What did you work at?";
		PCTalk[4] = "Really. Would you be able to fix a set of wonky traffic lights?";
		PCTalk[5] = "How much do you want?";
		PCTalk[6] = "Ok then I'll try to raise the cash. See you later";
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
				if(myIndex >= PCTalk.Length)
				{
					myIndex = PCTalk.Length-1;
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
			//colide.gameObject.GetComponent<FirstPersonController> ().setInDialogueToggle();
			
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
			//colide.gameObject.GetComponent<FirstPersonController> ().setInDialogueToggle();
			
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



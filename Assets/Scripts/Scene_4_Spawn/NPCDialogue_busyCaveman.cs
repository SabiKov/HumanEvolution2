using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;

public class NPCDialogue_busyCaveman : MonoBehaviour {
	
	//String arrays to hold dialogue info
	String[] NPCTalk = new String[4];
	String[] PCTalk = new String[4];
	int myIndex = 0;
	
	//A variable to hold thre time value during dialogue game-stop
	private float savedTimeScale;
	
	//A boolean to switch mouse-movement in fpc-Camera during dialogue
	bool myTalking = false;
	GameObject firstPersonControllerCamera;
	
	//reference to player script
	//GameObject playerScript;
	
	void Start()
	{
		//Initialize conversation values.
		//must be the same length each for this simple dialogue exchange
		NPCTalk[0] = "Hello";
		NPCTalk[1] = "Ug, What do you want";
		NPCTalk[2] = "Sorry, busy building stonehenge";
		NPCTalk[3] = "I did see some thing near the mushrooms";

		PCTalk[0] = "Hi";
		PCTalk[1] = "Actually, i'm looking for a book";
		PCTalk[2] = "...please";
		PCTalk[3] = "Wow he was in a hurry!";
	}
	
	
	void OnGUI () {
		//Display the Dialog.
		if(myTalking){
			
			//Build the little on-screen dialogue box
			GUI.BeginGroup(new Rect(Screen.width/4, (Screen.height/3)*2, Screen.width/2, Screen.height/3));
			GUI.Box(new Rect(0, 0, 400, 300), "You strike up a conversation with a \nfriendly looking person you meet on the street");
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
				UnPauseGame ();
				//give the player some money
				//playerScript.giveCash(1);
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
			colide.gameObject.GetComponent<FirstPersonController> ().setInDialogueToggle();
			
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




























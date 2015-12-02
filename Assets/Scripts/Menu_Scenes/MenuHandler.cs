using UnityEngine;
using System.Collections;
using System;

public class MenuHandler : MonoBehaviour {


    public void startButtonPressed(String sceneName) {
		
		/**
		 * Receives Scene name from onClick action on the canvas button
		 * If string = quit, then end game
		 * else load the unity scene named : sceneName
		 */ 
        if (sceneName == "quit") {
			Application.Quit ();
		} 
		else {
			Application.LoadLevel(sceneName);
		}
            
    }

}


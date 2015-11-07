using UnityEngine;
using System.Collections;
using System;

public class MenuHandler : MonoBehaviour {


    public void startButtonPressed(String sceneName) {

        //temp measure till all scenes connected to menu are built
        if (sceneName == "not_built_scene")
        {
            Debug.LogError("This Scene is not yet built");           
        }

        if (sceneName == "quit")
        {
            Application.Quit();
        }

        if (sceneName != "not_built_scene" && sceneName != "quit")
        {
            Application.LoadLevel(sceneName);
        }
        
            
    }


}


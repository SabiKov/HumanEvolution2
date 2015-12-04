using UnityEngine;
using System.Collections;

/**
 * A Class to manage the population of NPC's in the game
 * Implemented as a Singleton
 */
public class PopulationManager : MonoBehaviour {

    //max population - unfortuanetly cant make public (bad stuff happens!)
	private int MAX_POPULATION = 30;
    private static int currentPopulation;

	//lock for singleton creattion
	private static bool alreadyExists = false;
    private static PopulationManager populationManager;

    //private constructor
    private PopulationManager() {
        currentPopulation = 0;
    }

    /**
     * A public method to create the population manager if it does not exist
     * returns the same instance if the singleton already exists
     */
    public static PopulationManager createPopulationManager()
    {
        if (!alreadyExists)
        {
			Debug.Log("*** Population manager singleton created ***");
            GameObject go = new GameObject();
            populationManager = go.AddComponent<PopulationManager>();
            ///populationManager = new PopulationManager();
            alreadyExists = true;
            ///return populationManager;
        }
		Debug.Log("* * reference to singleton returned * *");
        return populationManager;
    }



    /*
     * Public access to PopulationManager variables
     */

    /**
     * A method to increase the current population figure
     * Return true if max population not yet reached
     */
    public bool roomForMore()
    {
        if (currentPopulation < MAX_POPULATION)
        {
            currentPopulation++;
            return true;
        }
        else {
            Debug.Log("Full Npc quota");
            return false;
        }
    }


	/*
     * A method to reduce the current population figure
     */
	public bool decreaseHeadCount() {
		
		if (currentPopulation >= 1) {
			currentPopulation--;
			return true;
		} 
		else {
			return false;
		}
	}


}


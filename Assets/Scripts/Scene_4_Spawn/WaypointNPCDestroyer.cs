using UnityEngine;
using System.Collections;

public class WaypointNPCDestroyer : MonoBehaviour {

    PopulationManager popManager;

    // Use this for initialization
	/**
	 * Geta reference to the population manager
	 */ 
    void Start()
    {
        popManager = PopulationManager.createPopulationManager();
    }

    // Update is called once per frame
    void Update()
    {
    }

    
	/**
	 * Destroys an npc and decreases population count by one
	 */ 
	void OnTriggerEnter(Collider colide)
    {

        //Debug.Log("collision name = " + colide.gameObject.name);

        if (colide.gameObject.tag == "NPC")
        {
			if( popManager.decreaseHeadCount() ){
				Destroy(colide.gameObject);
			}       
        }

    }

}

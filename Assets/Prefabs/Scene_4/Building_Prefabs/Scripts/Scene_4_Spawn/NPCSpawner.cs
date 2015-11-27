using UnityEngine;
using System.Collections;
using System;

public class NPCSpawner : MonoBehaviour {
	
	private int startTime;
    //position of spawn cylinder
    private Vector3 pos;
	//frequency of npc spawning
	public int spawnInterval;

	//direction npc is facing when spawned 0 -> 359
	public int npcFacing = 0;

    public GameObject[] npc;
	public GameObject[] firstWaypointArray;


    //script game objects
    PopulationManager popManager;
    NpcMovement npcMovement;

    /*
     * Initialization
     */
    void Start () {
        popManager = PopulationManager.createPopulationManager();

        startTime = (int) Time.time;
		//position of the npc spawnGO
		pos = this.transform.position;	
	}


    /*
     * Update is called once per frame
     */
    void Update () {

		if( SpawnTime() && popManager.roomForMore()){
			SpawnNewNPC();
		}
	}


    /**
     * returns true when spawn interval is reached
     */
    bool SpawnTime() {

		int currentTime = (int) Time.timeSinceLevelLoad;
		int timeDifference = currentTime - startTime;

		if(timeDifference > spawnInterval){
			startTime += spawnInterval;
			return true;
		}
		return false;
	}

    /**
     * Return first waypoint randomly, from waypoint array
     */
    public GameObject getFirstWaypoint() {

        int randomInt = UnityEngine.Random.Range(0, (firstWaypointArray.Length) );
        
        return firstWaypointArray[randomInt];
    }


    /**
     * Spawn a new npc
     */
    void SpawnNewNPC() {

        // Create NPC game object with rotation specified in inspector
        Quaternion spawnRotation2 = Quaternion.Euler(0, npcFacing, 0);
        //GameObject newNpc = (GameObject)Instantiate(npc, pos, spawnRotation2);
		GameObject newNpc = getNewNpc();

        if (newNpc != null) {
            releaseNpc(newNpc);
        }                  
    }

	GameObject getNewNpc(){
		int randomInt = UnityEngine.Random.Range(0, (npc.Length) );

		// Create NPC game object with rotation specified in inspector
		Quaternion spawnRotation2 = Quaternion.Euler(0, npcFacing, 0);
		GameObject newNpc = (GameObject)Instantiate(npc[randomInt], pos, spawnRotation2);

		return newNpc;
	}


    /**
     * Get movement script reference from newly created npc game object
     * Get next waypoint location and set this value on npc movement script
     */
    void releaseNpc( GameObject newNpc ) {

        GameObject firstWPoint = getFirstWaypoint();
        npcMovement = newNpc.GetComponent<NpcMovement>();
        npcMovement.SetNextWaypoint(firstWPoint);
    }


}










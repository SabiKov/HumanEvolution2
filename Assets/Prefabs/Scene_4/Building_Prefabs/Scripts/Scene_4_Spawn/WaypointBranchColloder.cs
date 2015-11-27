using UnityEngine;
using System.Collections;
using System;

public class WaypointBranchColloder : MonoBehaviour {

    
	public GameObject[] branchWaypoints_A;
    public GameObject[] branchWaypoints_B;


    void OnTriggerEnter(Collider colide)
    {
        NpcMovement npcMovement = null;
        //string tag = colide.tag;
        //Debug.Log("collision name = " + colide.gameObject.name);

        if (colide.tag == "NPC")
        {
            npcMovement = colide.gameObject.GetComponent<NpcMovement>();

            if (npcMovement != null) {
                chooseNextRoute(npcMovement);
            }    
        }

    }


    /**
    * Randonly pick the next waypoint for the NPC
    */
    private void chooseNextRoute(NpcMovement npcMov)
    {
        //throw new NotImplementedException();

        int randomInt = UnityEngine.Random.Range(0, 2);

		if (randomInt < 1)
        {
            Debug.Log("A route chosen");
            npcMov.SetNextWaypoint(branchWaypoints_A[0]);
        }
        else {
            Debug.Log("B route chosen");
            npcMov.SetNextWaypoint(branchWaypoints_B[0]);
        }
    }



}





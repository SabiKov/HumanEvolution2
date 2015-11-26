using UnityEngine;
using System.Collections;

public class NpcMovement : MonoBehaviour {

	//a navmesh for navigation - must bake landscape
	private NavMeshAgent navMeshAgent;
    private GameObject nextWaypoint = null;


	void Start (){
		navMeshAgent = GetComponent<NavMeshAgent>();
		HeadForNextWayPoint();
	}

    /**
     * If stopping-distance from waypoint, then move to next
     */
    void Update (){
		float closeToDestinaton = navMeshAgent.stoppingDistance * 2;
		if (navMeshAgent.remainingDistance < closeToDestinaton){
			HeadForNextWayPoint ();
		}
	}

    /**
     * Generic move to next waypoint
     */ 
	private void HeadForNextWayPoint (){

		navMeshAgent.SetDestination (nextWaypoint.transform.position);
	}


    /**
     * Public method to set the NPCs next waypoint
     */
    public void SetNextWaypoint(GameObject nextWP){
		this.nextWaypoint = nextWP;
	}

}






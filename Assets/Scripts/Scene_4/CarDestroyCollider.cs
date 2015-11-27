using UnityEngine;
using System.Collections;

public class CarDestroyCollider : MonoBehaviour {

	//public GameObject car_NorthGO;

	/*
	 * Placed on car GameObjects to destroy them at the
	 * end of the road
	 */
	private void OnTriggerEnter(Collider c)
	{
		string tag = c.tag;
		
		if("Car" == tag)
		{
			Destroy(this.gameObject);
		}
	}

}


	

	

	

	

	

	
	


using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider c)
	{
		string tag = c.tag;
		
		if("Wall" == tag || "Door" == tag)
		{
			c.GetComponent<MeshRenderer>().enabled = false;
		}		
	}

	private void OnTriggerExit(Collider c)
	{
		string tag = c.tag;
		
		if("Wall" == tag || "Door" == tag)
		{
			c.GetComponent<MeshRenderer>().enabled = true;
		}		
	}
}

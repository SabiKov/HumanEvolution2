using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.CompareTag("Wall") || c.gameObject.CompareTag("Door"))
		{
			c.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	private void OnTriggerExit(Collider c)
	{
		if(c.gameObject.CompareTag("Wall") || c.gameObject.CompareTag("Door"))
		{
			c.GetComponent<MeshRenderer>().enabled = true;
		}		
	}
}

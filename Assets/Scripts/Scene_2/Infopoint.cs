using UnityEngine;
using System.Text;
using System.Collections;

public class Infopoint : MonoBehaviour
{
	public GameObject popup, information;
	private bool offer, show, finished;

	public void Update()
	{
		if(offer)
		{
			popup.SetActive(true);
		}
		else
		{
			popup.SetActive(false);
		}
		if(show)
		{
			offer = false;
			information.SetActive(true);
		}
		if(finished)
		{
			show = false;
			information.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			offer = true;
		}		
	}
	
	private void OnTriggerExit(Collider c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			if(offer)
				offer = false;
		}		
	}
	
	private void OnTriggerStay(Collider c)
	{
		if(Input.GetKeyDown(KeyCode.X))
		{
			if(offer)
				show = true;
			else if(show)
				finished = true;
		}
	}
}

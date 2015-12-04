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
		string tag = c.tag;
		
		if ("Player" == tag)
		{
			offer = true;
		}		
	}
	
	private void OnTriggerExit(Collider c)
	{
		string tag = c.tag;
		
		if("Player" == tag)
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

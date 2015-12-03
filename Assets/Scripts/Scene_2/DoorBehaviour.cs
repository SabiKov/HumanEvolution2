using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour
{
	public AudioClip open;
	private AudioSource source;
	public PlayerScene2 player;
	private bool opening = false;
	public GameObject message;
	public string loadLevelString;
	
	public void Start()
	{
		source = GetComponent<AudioSource> ();
	}
	
	public void Update()
	{
		if(opening)
		{
			if (!source.isPlaying)
			{
				player.ReleasePlayer();
				Application.LoadLevel (loadLevelString);
			}
		}
	}
	
	private void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			message.SetActive(true);
		}		
	}

	private void OnTriggerExit(Collider c)
	{
		if(c.gameObject.CompareTag("Player"))
		{
			message.SetActive(false);
		}		
	}

	private void OnTriggerStay(Collider c)
	{
		if(Input.GetKeyDown(KeyCode.X))
		{
			player.FreezePlayer();
			opening = true;
			source.PlayOneShot(open, 1);
		}
	}

}


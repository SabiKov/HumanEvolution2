using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour
{
	public AudioClip open;
	private AudioSource source;
	public PlayerScene2 player;
	public bool opening = false;
	public GameObject message;
	public int loadLevel;
	
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
				player.unfreezePlayer();
				Application.LoadLevel (loadLevel);
			}
		}
	}
	
	private void OnTriggerEnter(Collider c)
	{
		string tag = c.tag;
		
		if("Player" == tag)
		{
			message.SetActive(true);
		}		
	}

	private void OnTriggerExit(Collider c)
	{
		string tag = c.tag;
		
		if("Player" == tag)
		{
			message.SetActive(false);
		}		
	}

	private void OnTriggerStay(Collider c)
	{
		if(Input.GetKeyDown(KeyCode.X))
		{
			player.freezePlayer();
			opening = true;
			source.PlayOneShot(open, 1);
		}
	}

}


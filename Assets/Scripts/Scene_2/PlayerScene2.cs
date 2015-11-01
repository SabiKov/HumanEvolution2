using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerScene2 : MonoBehaviour
{
	public PlayerScene2 player;
	public bool learning{get; set;}
	public bool taskCompleted{get; set;}
	private int items = 0;
	
	public void Awake()
	{
		DontDestroyOnLoad (this);
	}

	public void Update()
	{
		if (items == 3)
			taskCompleted = true;
	}
	
	private void OnTriggerEnter(Collider c)
	{
		string tag = c.tag;
		
		if ("Item_1" == tag)
		{
			Destroy(c.gameObject);
			items++;
		}
		
		else if ("Item_2" == tag)
		{
			Destroy(c.gameObject);
			items++;
		}
		
		else if ("Item_3" == tag)
		{
			Destroy(c.gameObject);
			items++;
		}
	}
	
	// Custom method
	public void freezePlayer()
	{
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition;
	}
	
	public void unfreezePlayer()
	{
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
	}

	public int getItems()
	{
		return items;
	}
	
}
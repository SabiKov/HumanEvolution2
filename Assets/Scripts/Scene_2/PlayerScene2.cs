using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerScene2 : MonoBehaviour
{
	public PlayerScene2 player;
	public bool learning{get; set;}
	public bool taskCompleted{get; set;}
	
	public void Awake()
	{
		DontDestroyOnLoad (this);
	}

	public void Update()
	{

	}
	
	private void OnTriggerEnter(Collider c)
	{

	}
	
	// Custom method
	public void FreezePlayer()
	{
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition;
	}
	
	public void ReleasePlayer()
	{
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
	}

	public bool PlayerHasQuestItem(string questItemTag)
	{
		return true;
	}

}
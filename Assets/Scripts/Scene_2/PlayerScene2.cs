using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;

public class PlayerScene2 : MonoBehaviour
{
	public PlayerScene2 player;
	public TextAsset playerJSON;
	private JSONNode dictionaryObject;
	public string[] learningTopics;
	protected Dictionary<string, bool> playerLearned;

	void Start()
	{
		playerLearned = new Dictionary<string, bool>();
		for(int i=0; i<learningTopics.Length; i++)
		{
			playerLearned.Add(learningTopics[i], false);
		}
		SetJSON();

	}
	
	public void Awake()
	{
		DontDestroyOnLoad(this);
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

	public void PlayerHasLearned(string topic)
	{
		if(playerLearned.ContainsKey(topic))
		{
			playerLearned[topic] = true;
		}
		SetTopicTrue(topic);
		Debug.Log ("PlayerHasLearned("+playerLearned[topic]+")");
	}

	public bool CheckWhatPlayerLearned(string topic)
	{
		Debug.Log (playerLearned.Count+" : "+playerLearned[topic]);
		if(playerLearned[topic])
		{
			return true;
		}
		else
		{
			return false;
		}		
	}

	void SetJSON()
	{
		JSONNode json = JSON.Parse(playerJSON.text);
		int i=0;
		foreach(var entry in playerLearned)
		{
			Debug.Log ("Found an entry");
			json[0]["playerLearned"][-1][entry.Key] = entry.Value.ToString();
			i++;
		}
		File.WriteAllText(Environment.CurrentDirectory + "/Assets/Resources/JSON/JSONPlayer.json", json.ToString());
	}

	void SetTopicTrue(string topic)
	{
		JSONNode json = JSON.Parse(playerJSON.text);
		json[0]["playerLearned"][0][topic].Value = "True";
		File.WriteAllText(Environment.CurrentDirectory + "/Assets/Resources/JSON/JSONPlayer.json", json.ToString());
	}

}
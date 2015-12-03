using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;


public class InfoDialogue : MonoBehaviour
{
	public GameObject infopoint;
	public TextAsset dialogueJSON;
	private string ipTAG;
	public int scene;
	public RectTransform panelTop, panelLeft, panelRight;
	public Button questionButton;
	private JSONNode infoObject;

	void Awake()
	{
		Debug.Log("InfoDialogue: Awake()");		
		getJSON ();
	}

	void Start ()
	{
		Debug.Log("InfoDialogue: Start()");		
		manageDialogue();
	}

	void onEnable()
	{		
		manageDialogue();
	}

	void OnDisable()
	{
		panelTop.GetComponent<Text>().text = infoObject["title"];
		panelRight.GetComponent<Text>().text = infoObject["description"];
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		
	}

	void getJSON()
	{
		ipTAG = infopoint.gameObject.tag;
		JSONNode json = JSON.Parse(dialogueJSON.text);
		for(int i=0; i<json.Count; i++)
		{			
			if(json[i]["scene"].AsInt == scene)
			{
				for(int j= 0; j<json[i]["infopoints"].Count; j++)
				{
					if(json[i]["infopoints"][j]["location"].Value == ipTAG)
					{
						infoObject = json[i]["infopoints"][j];
						return;
					}
				}
			}
		}
	}
	
	public void manageDialogue()
	{
		Debug.Log (infoObject.ToString());
		panelTop.GetComponent<Text>().text = infoObject["title"];
		panelRight.GetComponent<Text>().text = infoObject["description"];
		int buttons = infoObject["learn_more"].Count;
		
		for(int i=0; i<buttons; i++)
		{
			Button option = Instantiate(questionButton, Vector3.zero, Quaternion.identity) as Button;
			option.onClick.AddListener(() => DIALOGUE_BUTTON_CLICK(option));
			option.GetComponentInChildren<Text>().text = infoObject["learn_more"][i]["topic"];
			RectTransform rectTransform = option.GetComponent<RectTransform>();
			rectTransform.SetParent(panelLeft, false);
			rectTransform.offsetMin = new Vector2(10.0f, 5.0f);
			rectTransform.localScale = new Vector3(0.75f, 0.5f );
		}
	}
	
	public void DIALOGUE_BUTTON_CLICK(Button caller)
	{
		string button = caller.GetComponentInChildren<Text>().text;
		string test;
		for(int i=0; i<infoObject["learn_more"].Count; i++)
		{
			test = infoObject["learn_more"][i]["topic"];
			if(test.Equals(button))
			{
				panelRight.GetComponent<Text>().text = infoObject["learn_more"][i]["detail"];
				if(infoObject["learn_more"][i]["player_learning"] != null)
				{
					GameObject.FindWithTag("Player").GetComponent<PlayerScene2>().PlayerHasLearned(infoObject["learn_more"][i]["player_learning"]);
					Debug.Log ("Player learned about "+infoObject["learn_more"][i]["player_learning"]);
				}
			}
		}
	}
}

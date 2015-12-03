using UnityEngine;
using System.Collections;

public class MenuActions : MonoBehaviour
{
	public GameObject forNPC;

	public void MENU_ACTION_SetTask()
	{
		forNPC.GetComponent<NPCController> ().PlayerHelping(true);
	}

	public void MENU_ACTION_Finished()
	{
		forNPC.GetComponent<NPCController> ().SetFinished(true);
	}
}

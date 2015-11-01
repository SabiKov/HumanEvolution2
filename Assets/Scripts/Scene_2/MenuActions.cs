using UnityEngine;
using System.Collections;

public class MenuActions : MonoBehaviour
{
	public GameObject forNPC;

	public void MENU_ACTION_SetTask()
	{
		forNPC.GetComponent<NPCController> ().playerHelping(true);
	}

	public void MENU_ACTION_Finished()
	{
		forNPC.GetComponent<NPCController> ().setFinished(true);
	}
}

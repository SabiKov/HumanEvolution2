using UnityEngine;
using System.Collections;

public class Login_Register : MonoBehaviour {

	//static veriables
	public static string user = "", name = "";
	private string password = "", rePass = "", message = "";
	public float X;
	public float Y;
	public float Width;
	public float Height;
	private bool register = false;
	
	private void OnGUI()
	{
		GUI.Box (new Rect (340,1,700,490), "");
		GUI.Box (new Rect (552,1,274,50), message);

		
		if (register)
		{
			GUI.Label(new Rect (552,90,270,20),"Username");
			user = GUI.TextField(new Rect (552,110,280,20), user);

			GUI.Label(new Rect (552,138,280,20), "Name");
			name = GUI.TextField (new Rect (552,156,280,20), name);

			GUI.Label (new Rect (552,190,280,20), "Password");
			password = GUI.TextField(new Rect (552,210,280,20), password);

			GUI.Label(new Rect (552,240,280,20),"Re-password");
			rePass = GUI.TextField(new Rect (552,260,280,20),rePass, "*"[0]);
			
			GUILayout.BeginHorizontal();
			
			if (GUI.Button(new Rect (552,290,120,40),"Back"))
				register = false;
			
			if (GUI.Button(new Rect (682,290,120,40),"Register"))
			{
				message = "";
				
				if (user == "" || name == "" || password == "")
					message += "Please enter all the fields \n";
				else
				{
					if (password == rePass)
					{
						WWWForm form = new WWWForm();
						form.AddField("user", user);
						form.AddField("name", name);
						form.AddField("password", password);
						WWW w = new WWW("http://localhost:8080/register.php", form);
						StartCoroutine(registerFunc(w));
					}
					else
						message += "Your Password does not match \n";
				}
			}
			
			GUILayout.EndHorizontal();
		}
		else
		{
			GUI.Label(new Rect (552,138,280,20),"User:");
			user = GUI.TextField(new Rect (552,156,280,20),user);
			GUI.Label(new Rect (552,190,280,20),"Password:");
			password = GUI.TextField(new Rect (552,210,280,20),password, "*"[0]);
			
			GUILayout.BeginHorizontal();
			
			if (GUI.Button(new Rect (552,240,120,40),"Login"))
			{
				message = "";
				
				if (user == "" || password == "")
					message += "Please enter all the fields \n";
				else
				{
					WWWForm form = new WWWForm();
					form.AddField("user", user);
					form.AddField("password", password);
					WWW w = new WWW("http://f6-preview.awardspace.com/unitytutorial.com/login.php", form);
					StartCoroutine(login(w));
				}
			}
			
			if (GUI.Button(new Rect (702,240,120,40),"Register"))
				register = true;
			
			GUILayout.EndHorizontal();
		}
	}
	
	IEnumerator login(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			if (w.text == "login-SUCCESS")
			{
				print("WOOOOOOOOOOOOOOO!");
			}
			else
				message += w.text;
		}
		else
		{
			message += "ERROR: " + w.error + "\n";
		}
	}
	
	IEnumerator registerFunc(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			message += w.text;
		}
		else
		{
			message += "ERROR: " + w.error + "\n";
		}
	}
}





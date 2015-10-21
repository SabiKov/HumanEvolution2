/*
 *This is is used to allow a user to login using (Name & passowrd) and register 
 *their information if not a member all user information is stored in a myphpAdmin database
 * 
*/

using UnityEngine;
using System.Collections;

public class Login_Register : MonoBehaviour {

	//veriables to store user and name 
	public static string user = "", name = "";
	//veriable to store user password (message veriable is used to print if a user is Successfull when loging in or unsuccessful
	private string password = "", rePass = "", message = "";
	//boolen veriable to check if a user is registered 
	private bool register = false;
	
	private void OnGUI()
	{	//creates a GUI box to hold all the Gui components
		GUI.Box (new Rect (340,1,700,490), "");
		//cretaes a A small Gui Box to display message
		GUI.Box (new Rect (552,1,274,50), message);

		
		if (register)//open register if statement
		{
			//Register Form GUI
			GUI.Label(new Rect (552,90,270,20),"Username");
			user = GUI.TextField(new Rect (552,110,280,20), user);

			GUI.Label(new Rect (552,138,280,20), "Name");
			name = GUI.TextField (new Rect (552,156,280,20), name);

			GUI.Label (new Rect (552,190,280,20), "Password");
			password = GUI.TextField(new Rect (552,210,280,20), password);

			GUI.Label(new Rect (552,240,280,20),"Re-password");
			rePass = GUI.TextField(new Rect (552,260,280,20),rePass);
			

			//nested if statements 
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
		//End of Register form gui
		}//close Register if statement 
		else
		{ //login GUI
			//this part of code is excuted first showing the login option
			GUI.Label(new Rect (552,138,280,20),"User:");
			user = GUI.TextField(new Rect (552,156,280,20),user);
			GUI.Label(new Rect (552,190,280,20),"Password:");
			password = GUI.TextField(new Rect (552,210,280,20),password); //,"*"[0]

			//if statement to check if a user has clicked the login button if true 
			//the nested if statement will try check if user textfield and password textfield are empty
			//else it will go and check the php login script to validate the user
			//StartCorountin starts the login method 
			if (GUI.Button(new Rect (552,240,120,40),"Login"))
			{
				message = "";
				
				if (user == "" || password == "")
					message += "Please enter all the fields \n";
				else
				{
					//creates form data to post to web server(UsbWebServer)
					WWWForm form = new WWWForm();
					form.AddField("user", user);
					form.AddField("password", password);

					//access the web page(in my case the login.php script) 
					WWW w = new WWW("http://localhost:8080/login.php", form);
					StartCoroutine(login(w));
				}
			}
			// if user click on the register button the boolen is set to true which goes to excute the first if statement
			// on this OnGUI() method the result is a new ReGISteR FORM
			if (GUI.Button(new Rect (702,240,120,40),"Register"))
				register = true;	
		}
		//end of Login gui
	}//end else

	//this method trys to login a user to the system it takes www(which is used to access web pages)
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

	//this method trys to register a user to the system it takes www(which is used to access web pages)
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





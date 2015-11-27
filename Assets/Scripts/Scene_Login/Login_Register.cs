/*
 *This is is used to allow a user to login using (Name & passowrd) and register 
 *their information if not a member all user information is stored in a myphpAdmin database
 * 
*/

using UnityEngine;
using System.Collections;

public class Login_Register : MonoBehaviour {
	//veriables to store user and name 
	    public string user = "", Uname = "";
	//veriable to store user password (message veriable is used to print if a user is Successfull when loging in or unsuccessful
	public string password = "", rePass = "", message = "";
	//boolen veriable to check if a user is registered 
	private bool register = false;
	private int id;
	PlayerData player = new PlayerData();
	SaveSystem syst = new SaveSystem();

	public void setUser(string user){
		this.user = user;
	}

	public string getUser(){
		return user;
	}
	public void setUname(string Uname){
		this.Uname = Uname;
	}
	
	public string getUname(){
		return Uname;
	}
	public void setPassword(string password){
		this.password = password;
	}
	
	public string getPassword(){
		return password;
	}
	private void OnGUI()
	{	//creates a GUI box to hold all the Gui components
		GUI.Box (new Rect (120,1,500,490), "");
		//cretaes a A small Gui Box to display message
		GUI.Box (new Rect (116,1,504,50), message);

		
		if (register)//open register if statement
		{
			//Register Form GUI
			GUI.Label(new Rect (252,90,70,20),"Username");
			user = GUI.TextField(new Rect (252,110,280,20), user);

			GUI.Label(new Rect (252,138,180,20), "Name");
			Uname = GUI.TextField (new Rect (252,156,280,20), Uname);

			GUI.Label (new Rect (252,190,180,20), "Password");
			password = GUI.TextField(new Rect (252,210,280,20), password);

			GUI.Label(new Rect (252,240,280,20),"Re-password");
			rePass = GUI.TextField(new Rect (252,260,280,20),rePass);
			

			//nested if statements 
			if (GUI.Button(new Rect (252,290,120,40),"Back"))
				register = false;
			
			if (GUI.Button(new Rect (382,290,120,40),"Register"))
			{
				message = "";
				
				if (user == "" || name == "" || password == "")
					message += "Please enter all the fields \n";
				else
				{
					if (password == rePass)
					{

						//setUname(Uname);
						//setUser(user);
						//setPassword();
						Application.LoadLevel(2);
						//player.setName(Uname);
						//player.setUname(user);
						//player.setPassword(password);
						//saveScores();	
						PlayerPrefs.SetString("user",user);
						PlayerPrefs.SetString("uname",Uname);
						PlayerPrefs.SetString("pass",password);

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
			GUI.Label(new Rect (252,138,280,20),"User:");
			user = GUI.TextField(new Rect (252,156,280,20),user);
			GUI.Label(new Rect (252,190,280,20),"Password:");
			password = GUI.TextField(new Rect (252,210,280,20),password); //,"*"[0]

			//if statement to check if a user has clicked the login button if true 
			//the nested if statement will try check if user textfield and password textfield are empty
			//else it will go and check the php login script to validate the user
			//StartCorountin starts the login method 
			if (GUI.Button(new Rect (252,240,120,40),"Login"))
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
					//if(register){
						//SaveSystem.LoadState();
					//}
				}
			}
			// if user click on the register button the boolen is set to true which goes to excute the first if statement
			// on this OnGUI() method the result is a new ReGISteR FORM
			if (GUI.Button(new Rect (382,240,120,40),"Register"))
				register = true;	
		}
		//end of Login gui
	}//end else

	//this method trys to login a user to the system it takes www(which is used to access web pages)
	IEnumerator login(WWW w)
	{//
		yield return w;
			if (w.error == null)
				{
					if (w.text == "login-SUCCESS")
						{
							print("You have logged in !");
							Application.LoadLevel(2);

				            syst.LoadState();
						}
					else
						message += w.text;
				}
			else{
				  message += "ERROR: " + w.error + " ";
				}
	}//

	//this method trys to register a user to the system it takes www(which is used to access web pages)
	IEnumerator registerFunc(WWW w){
		yield return w;
			if (w.error == null)
		 	   {
				message += w.text;
			print("your registered and ready!");

			     Application.LoadLevel(2);
			syst.SaveState();
			   }
		else{
			message += "ERROR: " + w.error + " ";
			}
	}
	
	
//	public void saveScores() { 
//		PlayerPrefs.SetString("pass",password);
//	} 
	
	
	//getScores() { score1 = PlayerPrefs.GetInt("pass"); } 
}





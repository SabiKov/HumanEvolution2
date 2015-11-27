using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem : MonoBehaviour {
	string message="";
	Boolean saved_in_the_database;
	//public Player player;
	PlayerData data = new PlayerData ();
	String User; 
		String names;
			String Passowrd ;
	//public String name = "bens";
	// Use this for initialization


	public void SaveState () {

		data.posX = transform.position.x;
		data.posY = transform.position.y;
		data.posZ = transform.position.z;

		data.rotX = transform.eulerAngles.x;
		data.rotY = transform.eulerAngles.y;
		data.rotZ = transform.eulerAngles.z;
		//data.posX.ToString ();
		//player = new Player ();

		//String User = regis.getUser();
		//String Name = regis.getUname ();
		//String Passowrd = regis.getPassword ();
		 //User = data.getUName();
		// names = data.getName ();
		 //Passowrd = data.getPassword ();
		String userr= PlayerPrefs.GetString ("user");
		String uname = PlayerPrefs.GetString ("uname");
		String passwrd = PlayerPrefs.GetString ("pass");

		WWWForm form = new WWWForm();

			form.AddField("user", userr);
			form.AddField("name", uname);
		    form.AddField("password", passwrd);
			form.AddField("positionX", data.posX.ToString());
			form.AddField("positionY", data.posY.ToString());
			form.AddField("positionZ", data.posZ.ToString());
			form.AddField("rotateX", data.rotX.ToString());
			form.AddField("rotateY", data.rotY.ToString());
			form.AddField("rotateZ", data.rotZ.ToString());
			WWW w = new WWW("http://localhost:8080/register.php", form);
			StartCoroutine(saved(w));

	}
	
	// Update is called once per frame
	public void LoadState () {
		StartCoroutine (Retrieve());
	}


	IEnumerator Retrieve() {
		// Create a Web Form, including player ID
		var form = new WWWForm();
		//form.AddField("user", "ben");
		Debug.Log("submitting "+form+" to "+"http://localhost:8080/get" +
			"login.php");
		WWW request = new WWW("http://localhost:8080/login.php", form);
		yield return request;
	

		    float x = data.posX;
	      	float y = data.posY;
	       	float z = data.posZ;

		float rox = data.rotX;
		float roy = data.rotY;
		float roz = data.rotZ;
			// assign the position by putting the parsed numbers into a vector3
			transform.position = new Vector3(x,y,z);
			transform.rotation = Quaternion.Euler(rox, roy, roz);
	}




	IEnumerator saved(WWW w)
	{
		yield return w;
		if (w.error == null)
		{
			if (w.text == "login-SUCCESS")
			{
				print("WOOOOOOOOOOOOOOO!");
				//saved_in_the_database =true;
			}
			else
				message += w.text;
		}
		else
		{
			message += "ERROR: " + w.error + "\n";
		}
	}
		

}

//[Serializable]
class PlayerData{

	public float posX;
	public float posY;
	public float posZ;

	public float rotX;
	public float rotY;
	public float rotZ;
	
}

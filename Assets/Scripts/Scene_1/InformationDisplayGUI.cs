using UnityEngine;
using System.Collections;

public class InformationDisplayGUI : MonoBehaviour {


    private string introLine1 = "The Stone Age was a time in history when early humans used tools and weapons made out of stone.";
    private string introLine2 = "It lasted from when the first stone tools were made, by our ancestors, about 3.4 million years";
    private string introLine3 = "ago until the introduction of metal tools a few thousand years ago. The Stone Age is divided into";
    private string introLine4 = "three periods and the exact dates for each period vary across the world. The Old Stone";
    private string introLine5 = "(Palaeolithic) Age lasted from the first use of stones until the end of the last Ice Age.";
    private string introLine6 = "Age lasted from the first use of stones until the end of the last Ice Age. The Middle Stone";
    private string introLine7 = "(Mesolithic) Age lasted from the end of the last Ice Age until the start of farming.";
    private string introLine8 = "The New Stone (Neolithic) Age lasted from the start of farming until the first use of metal.";
    private string introLine9 = "The term lithic comes from the Ancient Greek word for stone or rock.";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        ShowIntro();


    }

    public void ShowIntro() {
        GUI.Box(new Rect(100, 50, Screen.width - 200, Screen.height - 300), 
            introLine1 + "\n" +
            introLine2 + "\n" +
            introLine3 + "\n" +
            introLine4 + "\n" +
            introLine5 + "\n" +
            introLine6 + "\n" +
            introLine7 + "\n" +
            introLine8 + "\n"
            );
    }
}

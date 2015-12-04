using UnityEngine;
using System.Collections;

public class IntroductionPanel : MonoBehaviour {

    /// <summary>
    /// Hold UI game object elements
    /// </summary>
    public GameObject introductionPanel;

    private bool display = true;

    void Update()
    {
        if (!display)
        {
            introductionPanel.SetActive(true);
        }
        else
        {
            introductionPanel.SetActive(false);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if ("Player" == tag) {
            display = !display;
        }
        Debug.Log("Display: " + display);
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if ("Player" == tag)
        {
            display = false;
        }
    }
}

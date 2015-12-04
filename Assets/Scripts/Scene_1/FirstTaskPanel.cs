using UnityEngine;
using System.Collections;

public class FirstTaskPanel : MonoBehaviour {


    /// <summary>
    /// Hold UI game object elements
    /// </summary>
    public GameObject firstTaskPanel;

    private bool display = false;

    void Update()
    {
        if (display)
        {
            firstTaskPanel.SetActive(true);
        }
        else
        {
            firstTaskPanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if ("Player" == tag)
        {
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

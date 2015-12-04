using UnityEngine;
using System.Collections;

/// <summary>
/// Show and Hide popup GUI
/// </summary>
public class SecondTaskPanel : MonoBehaviour {



    /// <summary>
    /// Hold UI game object elements
    /// </summary>
    public GameObject secondTaskPanel;

    private bool display = false;

    void Update()
    {
        if (display)
        {
            secondTaskPanel.SetActive(true);
        }
        else
        {
            secondTaskPanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if ("Player" == tag)
        {
            display = false;
        }
        Debug.Log("Display: " + display);
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if ("Player" == tag)
        {
            display = true;
        }
    }
}

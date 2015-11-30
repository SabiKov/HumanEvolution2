using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScaleManagerCanvas : MonoBehaviour {
    // Variable for manipulating canvas behavior on different screen size 
    private CanvasScaler canvasScaler;

    // Initial the canvas scale based on the screen resolution
    void Start() {
        canvasScaler = GetComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
    }

}

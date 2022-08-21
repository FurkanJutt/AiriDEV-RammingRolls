using UnityEngine;
using System.Collections;

public class takeScreenShot : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        InvokeRepeating("screenshot", 5, 5);
    }

    string resolution;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            screenshot();


        }

    }

    public void screenshot()
    {
        Screen.SetResolution(640, 1136, false);
        resolution = "" + Screen.width + "X" + Screen.height;
        ScreenCapture.CaptureScreenshot("ScreenShot-" + resolution + "-" + PlayerPrefs.GetInt("number", 0) + ".png");
        PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number", 0) + 1);
        //Debug.Log ("takenShot with " + resolution);
    }
}

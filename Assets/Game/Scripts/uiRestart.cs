using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiRestart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

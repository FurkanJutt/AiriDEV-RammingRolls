using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deactivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "Level1") {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

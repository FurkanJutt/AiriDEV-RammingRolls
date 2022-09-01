using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	static public GameManager gm;
	public Text CurrentLeveltext, NextLeveltext;
	public GameObject HUDUI;
	public GameObject LevelCompleteUI;
	public GameObject LevelFailUI;
	public Image LevelProgressImage;
	public GameObject FinishObj;
	public GameObject PlayerOBj;
	public bool boolGameOver;
	public bool boolGameComplete;
	public GameObject BallDestryEffect;
	public GameObject LevelName;
	private void Awake ()
	{
		gm = this;
	}
	GameObject obj;
	void OnEnable()
	{
		
		//obj = GameObject.Find("Platfrom");
	//	obj.GetComponent<MeshRenderer> ().material.color = new Color (Random.Range(0.1f,.8f),Random.Range(0.1f,.8f),Random.Range(0.1f,0.8f));
		HUDUI.SetActive (true);
		LevelCompleteUI.SetActive (false);
		LevelFailUI.SetActive (false);
		LevelName = GameObject.Find ("LevelNo");
		LevelName.GetComponent<TextMesh>().text = SceneManager.GetActiveScene ().name.ToString();
		CurrentLeveltext.text = "" + SceneManager.GetActiveScene ().buildIndex;
		NextLeveltext.text = "" + (SceneManager.GetActiveScene ().buildIndex +1);
		PlayerOBj = GameObject.Find ("Player");
		FinishObj = GameObject.Find ("Finish");

		if(PlayerOBj)
			startDist =Vector3.Distance (PlayerOBj.transform.position,FinishObj.transform.position);

	}
	float dist,startDist;
	void Update()
	{
		if (PlayerOBj)
        {
			dist = Vector3.Distance (PlayerOBj.transform.position,FinishObj.transform.position);
			LevelProgressImage.fillAmount = (1- (dist/startDist));
        }
	}

	public void ShowGameOver()
	{
		if (boolGameComplete)
			return;
		//if (AdManager.instance) {
		//	AdManager.instance.showInterstitial ();
		//}
		boolGameOver = true;
		HUDUI.SetActive (false);
		LevelFailUI.SetActive (true);
		//Admanager.instance.ShowFullScreenAd();
	}

	public void ShowGameWin()
	{
		if (boolGameOver)
			return;
		//	if (AdManager.instance) {
		//		AdManager.instance.ShowAd ();
		///	}

		PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name, 1);
		boolGameComplete = true;
		HUDUI.SetActive (false);
		LevelCompleteUI.SetActive (true);
		//Admanager.instance.ShowFullScreenAd();
	}

	public void RestartGame()
	{
		
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		//Admanager.instance.ShowFullScreenAd();
	}
	public void NextLevelsButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 100)
        {
            SceneManager.LoadScene("Menu");
        }
		else
        {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
			//Admanager.instance.RequestBanner();
        }
	}
	public void HomeButton()
	{
		SceneManager.LoadScene ("Menu");
	}
}
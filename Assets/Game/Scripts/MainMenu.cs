using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public GameObject MenuPage;
	public GameObject LevelSelection;
	public Transform LevelParent;
	void Start ()
	{
		Debug.Log(LevelParent.childCount);
		MenuPage.SetActive (true);
		LevelSelection.SetActive (false);
		PlayerPrefs.SetInt ("Level0", 1);
		for (int i = 0; i < LevelParent.childCount; i++) 
		{
			PlayerPrefs.SetInt ("Level"+i+1, 0);
			LevelParent.GetChild (i).name = "Level" + (i + 1);
			LevelParent.GetChild (i).GetChild (0).GetComponent<Text> ().text = "" + (i + 1);
			if (PlayerPrefs.GetInt ("Level" + i) > 0) 
			{
				LevelParent.GetChild (i).GetChild (1).gameObject.SetActive (false);
			} 
			else 
			{
				LevelParent.GetChild (i).GetChild (1).gameObject.SetActive (true);
				LevelParent.GetChild(i).GetComponent<Button>().interactable = false;
			}
		}
	}

	public void PlayButton()
	{
	//	if (AdManager.instance) {
	//		AdManager.instance.ShowAd ();
	//	}
		MenuPage.SetActive (false);
		LevelSelection.SetActive (true);
	}

	public void LevelPlayButton()
	{
		string name = EventSystem.current.currentSelectedGameObject.name;
		SceneManager.LoadScene (name);
	}
	public void BackToMenu(){
		MenuPage.SetActive (true);
		LevelSelection.SetActive (false);
	}
}

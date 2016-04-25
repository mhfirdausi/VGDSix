using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public Button startText;

	void Start () {
		startText = startText.GetComponent<Button> ();
	}
	
	public void LoadLevelSelect() {
		SceneManager.LoadScene ("LevelSelect");
	}
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour {

	public Canvas exitPanel;
	public Button startButton;
	public Button exitButton;

	void Start () {
		exitPanel = exitPanel.GetComponent<Canvas> (); 
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		exitPanel.enabled = false;
	}

	public void exitSelect(){
		exitPanel.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;

	}

	public void exitYes() {
		Application.Quit ();
	}

	public void exitNo() {
		exitPanel.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;

	}
}

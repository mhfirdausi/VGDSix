using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

	public Button beginButton;
	public Button yeezyButton;
	public Button futureButton;
	public Canvas yeezyMenu;	
	public Canvas futureMenu;

	void Start () {
		beginButton = beginButton.GetComponent<Button> ();
		yeezyButton = yeezyButton.GetComponent<Button> ();
		futureButton = futureButton.GetComponent<Button> ();
		yeezyMenu = yeezyMenu.GetComponent<Canvas> (); 
		futureMenu = futureMenu.GetComponent<Canvas> ();
		yeezyMenu.enabled = false;
		futureMenu.enabled = false;

	}

	public void yeezyPress() {
		yeezyMenu.enabled = true;
		futureMenu.enabled = false;
	}

	public void futurePress() {
		yeezyMenu.enabled = false;
		futureMenu.enabled = true;
	}

	public void loadYeezy()
	{
		SceneManager.LoadScene ("TLOP");

	}

	public void loadFuture()
	{
		SceneManager.LoadScene ("EVOL");

	}
}
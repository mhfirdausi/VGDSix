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
	public Vector3 startPoint;
	public Vector3 endPointEVOL;
	public Canvas ScrollView;

	void Start () {
		beginButton = beginButton.GetComponent<Button> ();
		yeezyButton = yeezyButton.GetComponent<Button> ();
		futureButton = futureButton.GetComponent<Button> ();
		yeezyMenu = yeezyMenu.GetComponent<Canvas> (); 
		futureMenu = futureMenu.GetComponent<Canvas> ();
		yeezyMenu.enabled = false;
		futureMenu.enabled = false;

		startPoint = transform.position;
		endPointEVOL = new Vector3(348, 0, 0);

	}

	public void yeezyPress() {
		yeezyMenu.enabled = true;
		futureMenu.enabled = false;
	}

	public void futurePress() {
		yeezyMenu.enabled = false;
		futureMenu.enabled = true;
		//ScrollView.transform.position = endPointEVOL;
	}

	public void loadMain()
	{
		SceneManager.LoadScene ("Sport N Bass");

	}

	public void loadTutorial()
	{
		SceneManager.LoadScene ("tutorial");

	}

	public void exitGame()
	{
		Application.Quit ();

	}
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

	public Button beginButton;
	public Button tutButton;
	public Button EDMButton;
	public Button soonButton;
	public Canvas tutMenu;	
	public Canvas EDMMenu;
	public Canvas soonMenu;
	public Canvas startTut;
	public Canvas startEDM;
	public Canvas startSoon;
	public Image tutImage;
	public Image EDMImage;
	public Image soonImage;
	public Image selectLevel;

	void Start () {
		beginButton = beginButton.GetComponent<Button> ();
		tutButton = tutButton.GetComponent<Button> ();
		EDMButton = EDMButton.GetComponent<Button> ();
		soonButton = soonButton.GetComponent<Button> ();
		tutMenu = tutMenu.GetComponent<Canvas> (); 
		EDMMenu = EDMMenu.GetComponent<Canvas> ();
		soonMenu = soonMenu.GetComponent<Canvas> ();
		tutImage = tutImage.GetComponent<Image> ();
		EDMImage = EDMImage.GetComponent<Image> ();
		soonImage = soonImage.GetComponent<Image> ();
		startTut = startTut.GetComponent<Canvas> ();
		startEDM = startEDM.GetComponent<Canvas> ();
		startSoon = startSoon.GetComponent<Canvas> ();
		tutMenu.enabled = false;
		EDMMenu.enabled = false;
		soonMenu.enabled = false;
		selectLevel.enabled = true;
		startTut.enabled = false;
		startEDM.enabled = false;
		startSoon.enabled = false;

	}

	public void tutPress() {
		tutMenu.enabled = true;
		EDMMenu.enabled = false;
		soonMenu.enabled = false;
		selectLevel.enabled = false;
		startTut.enabled = false;
		startEDM.enabled = false;
		startSoon.enabled = false;

		//Opacity modifications.
		Color x = tutImage.color;
		x.a = 1;
		tutImage.color = x;

		Color y = EDMImage.color;
		y.a = 0.3f;
		EDMImage.color = y;

		Color z = soonImage.color;
		z.a = 0.3f;
		soonImage.color = z;
	}

	public void EDMPress() {
		tutMenu.enabled = false;
		EDMMenu.enabled = true;
		soonMenu.enabled = false;
		selectLevel.enabled = false;
		startTut.enabled = false;
		startEDM.enabled = false;
		startSoon.enabled = false;

		//Opacity modifications.
		Color x = EDMImage.color;
		x.a = 1;
		EDMImage.color = x;

		Color y = tutImage.color;
		y.a = 0.3f;
		tutImage.color = y;

		Color z = soonImage.color;
		z.a = 0.3f;
		soonImage.color = z;
	}

	public void soonPress() {
		tutMenu.enabled = false;
		EDMMenu.enabled = false;
		soonMenu.enabled = true;
		selectLevel.enabled = false;
		startTut.enabled = false;
		startEDM.enabled = false;
		startSoon.enabled = false;

		//Opacity modifications.
		Color x = soonImage.color;
		x.a = 1;
		soonImage.color = x;

		Color y = EDMImage.color;
		y.a = 0.3f;
		EDMImage.color = y;

		Color z = tutImage.color;
		z.a = 0.3f;
		tutImage.color = z;
	}

	public void startTutScreen()
	{
		startTut.enabled = true;
		//startEDM.enabled = false;
		//startSoon.enabled = false;
	}

	public void startEDMScreen()
	{
		//startTut.enabled = false;
		startEDM.enabled = true;
		//startSoon.enabled = false;
	}

	public void startSoonScreen()
	{
		//startTut.enabled = false;
		//startEDM.enabled = false;
		startSoon.enabled = true;
	}

	public void loadMain()
	{
		SceneManager.LoadScene ("Sport N Bass");

	}

	public void loadTutorial()
	{
		SceneManager.LoadScene ("tutorial");

	}

	public void mainMenu()
	{
		SceneManager.LoadScene ("Start");

	}

	public void exitGame()
	{
		Application.Quit ();

	}
}




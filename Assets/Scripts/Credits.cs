using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public Canvas peoplePanel;
	public Canvas refPanel;

	void Start () {
		peoplePanel.enabled = true;
		refPanel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sports ()
	{
		Application.OpenURL("https://edmroyaltyfree.net");
	}

	public void bigroom ()
	{
		Application.OpenURL("https://edmroyaltyfree.net");
	}

	public void bit ()
	{
		Application.OpenURL("http://opengameart.org/content/8-bit-jump-1");
	}

	public void emot ()
	{
		Application.OpenURL("https://www.youtube.com/watch?v=lQYfa9XKGns");
	}


	public void wagna ()
	{
		Application.OpenURL("http://www.freesound.org/people/Wagna/sounds/326418/");
	}

	public void noodles ()
	{
		Application.OpenURL(" http://www.freesound.org/people/richienoodles/sounds/178555/");
	}

	public void robot ()
	{
		Application.OpenURL("http://opengameart.org/content/8-bit-sound-effects-library");
	}

	public void refSelect()
	{
		peoplePanel.enabled = false;
		refPanel.enabled = true;
	}

	public void peopleSelect()
	{
		peoplePanel.enabled = true;
		refPanel.enabled = false;
	}
}

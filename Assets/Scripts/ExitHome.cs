using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitHome : MonoBehaviour {

	public void exitHome() {
		SceneManager.LoadScene ("Start");
	}

	public void credits() {
		SceneManager.LoadScene ("Credits");
	}
}

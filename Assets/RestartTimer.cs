using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartTimer : MonoBehaviour {

	public Text timerLeft;
	private float timeLeft = 3.0f;
	private float startTime;

	void Update()
	{
		startTime = Time.time;
		timeLeft -= Time.deltaTime;

		var seconds = timeLeft % 60;

		timerLeft.text = string.Format ("{0:0}",  seconds);
	}
}

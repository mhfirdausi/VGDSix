using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerLabel;
	private float time;

	void Update() {
		time += Time.deltaTime;

		var minutes = time / 60;
		var seconds = time % 60;

		timerLabel.text = string.Format ("{0:0}:{1:00}/2:48", minutes, seconds);
	}
}
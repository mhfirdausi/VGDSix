using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerLabel;
	private float time;

	public MusicLevelController musController;

	void Awake()
	{
		musController = GameObject.FindGameObjectWithTag ("MusicController").GetComponent<MusicLevelController>();
	}
	void Update() {
		TimeText ();
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.0f);
		time += Time.deltaTime;

		var minutes = time / 60;
		var seconds = time % 60;

		timerLabel.text = string.Format ("{0:0}:{1:00}/2:48", minutes, seconds);
	}

	void TimeText()
	{
		float currentTime = musController.currentSource.time;
		float wholeTime = musController.currentSource.clip.length;
		var minutes = currentTime / 60;
		var seconds = currentTime % 60;
		var minutesTotal = wholeTime / 60;
		var secondsTotal = wholeTime % 60;
        if(currentTime == 0)
        {
            timerLabel.text = "Get ready!";
        }
        else
        {
            timerLabel.text = string.Format("{0:0}:{1:00}/{0:2}:{3:00}", minutes, seconds, minutesTotal, secondsTotal);
        }
		
	}
}
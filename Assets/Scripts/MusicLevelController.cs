using UnityEngine;
using System.Collections;

public class MusicLevelController : MonoBehaviour {

    public InMusicGroup musicLevel;

    public float levelSize;

    public AudioSource currentSource;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (currentSource != null)
            {
                currentSource.Play();
            }
            else
            {
                Debug.Log("ERROR: Audio source not found when playing.");
            }
        }
    }
    
    public void stopPlayingSong()
    {
        Debug.Log("Need to stop!");
        if (currentSource != null)
        {
            Debug.Log(currentSource.time);
            currentSource.Stop();
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when stopping.");
        }
    }

    //Functions are the same, may potentially be different in the future?
    public void slowDownSong(float pitchChange)
    {
        Debug.Log("Need to slow down!");
        if (currentSource != null)
        {
            currentSource.pitch = pitchChange;
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when slowing.");
        }
    }
    
    public void speedUpSong(float pitchChange)
    {
        Debug.Log("Need to speed up!");
        if (currentSource != null)
        {
            currentSource.pitch = pitchChange;
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when slowing.");
        }
    }
    public void playSongNormal()
    {
        Debug.Log("Resuming normal playback");
        if (currentSource != null)
        {
            Debug.Log(currentSource.time);
            currentSource.pitch = 1f;
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when going back to normal.");
        }
    }

    public void playSongAtPosition(float position)
    {

    }
} 

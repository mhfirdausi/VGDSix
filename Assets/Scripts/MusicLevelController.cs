using UnityEngine;
using System.Collections;

public class MusicLevelController : MonoBehaviour {

    private bool showWaveform;
    private bool isPaused;

    private SpriteRenderer ren; 
    public InMusicGroup musicLevel;

    public float levelSize;

    public AudioSource currentSource;
	// Use this for initialization
	void Start () {
        showWaveform = false;
        isPaused = false;
        ren = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
                currentSource.Pause();
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
                currentSource.UnPause();
            }
        }
        //debug: show waveform
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(!showWaveform)
            {
                ren.enabled = true;
                showWaveform = true;
            }
            else
            {
                ren.enabled = false;
                showWaveform = false;
            }
        }
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

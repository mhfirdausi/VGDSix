using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MusicLevelController : MonoBehaviour {

    private bool showWaveform;
    private bool isPaused;

    private SpriteRenderer ren; 
    public InMusicGroup musicLevel;

    public float levelSize;

    private float slowDownSpeed;
    private float speedUpSpeed;
    private player currentPlayer;

    public AudioSource currentSource;

    public UnityEvent slowDownMusicEvent;
    public UnityEvent speedUpMusicEvent;
    public UnityEvent playNormalMusicEvent;

    private bool canSpeedUp, canSlowDown, canResumeNormal;

    void Start () {
        showWaveform = false;
        isPaused = false;
        canSlowDown = canSpeedUp = canResumeNormal = true;
        ren = this.GetComponent<SpriteRenderer>();
        slowDownSpeed = player.speedDownMult;
        speedUpSpeed = player.speedUpMult;
        try
        {
            currentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("MusicLevel can't find player! " + e.Message);
        }
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
        if (currentSource != null)
        {
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
        if (currentSource != null)
        {
            if(canSlowDown)
            {
                Debug.Log("Need to slow down!");
                currentSource.pitch = slowDownSpeed;
                Debug.Log(currentPlayer.transform.position.z);
                canSlowDown = false;
                canSpeedUp = true;
                canResumeNormal = true;
            }
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when slowing.");
        }
    }
    
    public void speedUpSong(float pitchChange)
    {
        
        if (currentSource != null)
        {
            if(canSpeedUp)
            {
                Debug.Log("Need to speed up!");
                currentSource.pitch = speedUpSpeed;
                Debug.Log(currentPlayer.transform.position.z);
                canSpeedUp = false;
                canSlowDown = true;
                canResumeNormal = true;
            }
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when slowing.");
        }
    }
    public void playSongNormal()
    {
        if (currentSource != null)
        {
            if(canResumeNormal)
            {
                Debug.Log("Normal! Song time: " + currentSource.time);
                Debug.Log("Expected time: " + DeterminePosition());
                currentSource.pitch = 1f;
                currentSource.time = DeterminePosition();
                canSpeedUp = true;
                canSlowDown = true;
                canResumeNormal = false;
            }
        }
        else
        {
            Debug.Log("ERROR: Audio source not found when going back to normal.");
        }
    }

    public void playSongAtPosition(float position)
    {

    }

    private float DeterminePosition()
    {
        return currentPlayer.transform.position.z / player.playerSpeed;
    }
} 

using UnityEngine;
using System.Collections;

public class MusicLevelController : MonoBehaviour {

    public InMusicGroup musicLevel;

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
}

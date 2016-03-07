using UnityEngine;
using System.Collections;

public class MusicLevelController : MonoBehaviour {

    public InMusicGroup musicLevel;

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
            if (musicLevel != null)
            {
                InAudio.Music.Play(musicLevel);
            }
            else
            {
                Debug.Log("Music not assigned to scene.");
            }
        }
    }
        
}

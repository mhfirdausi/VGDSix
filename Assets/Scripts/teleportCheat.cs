using UnityEngine;
using System.Collections;

public class teleportCheat : MonoBehaviour
{

    public GameObject checkpoint;
    public player player;
    public KeyCode key;
    // Update is called once per frame
    private MusicLevelController levelController;
    void Awake()
    {
        levelController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicLevelController>();
    }
	void Update ()
    {
        if (Input.GetKeyDown(key))
        {
            player.transform.position = checkpoint.transform.position;
            levelController.playSongAtPosition();
        }
	}
}

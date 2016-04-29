using UnityEngine;
using System.Collections;

public class teleportCheat : MonoBehaviour
{

    public GameObject checkpoint;
    public player player;
    public KeyCode key;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(key))
        {
            player.transform.position = checkpoint.transform.position;
        }
	}
}

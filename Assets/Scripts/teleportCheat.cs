using UnityEngine;
using System.Collections;

public class teleportCheat : MonoBehaviour
{

    public GameObject checkpoint;
    public player player;
	// Update is called once per frame
	void Update ()
    {
        Vector3 x= new Vector3(player.transform.position.x, player.transform.position.y+40, player.transform.position.z);
        checkpoint.transform.position = x;
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.transform.position = checkpoint.transform.position;
        }
	}
}

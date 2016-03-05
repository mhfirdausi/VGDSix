using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Renderer>().enabled = false;

        if (other.gameObject.CompareTag("Player"))
        {
            player.points = player.points + 5;
            Debug.Log("points = " + player.points);
        }
    }
}

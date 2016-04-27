using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public float speed = 15f;

    public AudioSource collectSound;
    public Renderer myRenderer;
    void Start () {
        collectSound = GetComponent<AudioSource>();
	}
	
	void Update () {
       
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            collectSound.Play();
            if (player.heat >= 2)
            {
                player.heat = player.heat - 3;
            }
			//Upped to 1000 because why not.
            player.points = player.points + 1000;
            myRenderer.enabled = false;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    

    public float speed = 15f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            player.points = player.points + 5;
            Destroy(gameObject);
        }
    }
}

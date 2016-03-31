using UnityEngine;
using System.Collections;

public class jetpackparticle : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        if (Input.GetKey("z") && player.heat <100)
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
}

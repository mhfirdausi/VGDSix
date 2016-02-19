using UnityEngine;
using System.Collections;

public class BoxFall : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}

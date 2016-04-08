using UnityEngine;
using System.Collections;

public class BluePlate : MonoBehaviour {

    public Rigidbody playerRigidBody;

    // Use this for initialization
    void Start () {
        playerRigidBody = GameObject.Find("playerCylinder").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.z, player.blueBoxJump, playerRigidBody.velocity.z);
        }
    }

}

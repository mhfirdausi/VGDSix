using UnityEngine;
using System.Collections;

public class BluePlate : MonoBehaviour {

    public GameObject myPlayer;
    public player currentPlayerScript;
    public Rigidbody playerRigidBody;
    public Animator anim;

    // Use this for initialization
    void Awake () {
        myPlayer = GameObject.FindWithTag("Player");
        playerRigidBody = GameObject.Find("playerCylinder").GetComponent<Rigidbody>();
        currentPlayerScript = myPlayer.GetComponent<player>();
        anim = GameObject.Find("run").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.z, player.blueBoxJump, playerRigidBody.velocity.z);
            currentPlayerScript.isFalling = true;
        }
    }

}

using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float playerSpeed;
    private Vector3 dir;
    public float jumpHeight = 18f;

    public Rigidbody playerRigidBody;
    private bool isFalling = false;

    void Start () {
        dir = Vector3.forward;
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.Space) && isFalling == false)
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, playerRigidBody.velocity.y + jumpHeight, playerRigidBody.velocity.y);
        }

        isFalling = true;

        float distanceToMove = playerSpeed * Time.deltaTime;
        transform.Translate(dir * distanceToMove);
	}

    void OnCollisionStay()
    {
        isFalling = false;
    }
}

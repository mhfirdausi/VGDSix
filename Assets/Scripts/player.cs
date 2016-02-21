using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public static float playerSpeed=50;
    private Vector3 dir;
    public static float jumpHeight = 70f;

    public Rigidbody playerRigidBody;
    private bool isFalling = false;
    private int jumps;

    void Start () {
        dir = Vector3.forward;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && (isFalling == false || jumps < 1))
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x,  jumpHeight, playerRigidBody.velocity.y);
            jumps++;
        }

        isFalling = true;

        
	}

    void FixedUpdate()
    {
        float distanceToMove = playerSpeed * Time.deltaTime;
        transform.Translate(dir * distanceToMove);
    }

    void OnCollisionStay()
    {
        isFalling = false;
        jumps = 0;
    }
}

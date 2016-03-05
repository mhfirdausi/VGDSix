using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    public static int points = 0;

    public static bool greenPower;
    public static bool redPower;
    public static bool bluePower;

    public static float speedDownTimer = 3.5f;
    public static float speedDownMult = .5f;
    public static float speedUpTimer = 3.5f;
    public static float speedUpMult = 2f;

    public static float blueBoxJump = 150f;



    public static float playerSpeed= 50f;
    public static float jumpHeight = 70f;
    private Vector3 dir;

    public Rigidbody playerRigidBody;
    private bool isFalling = false;
    public int jumps;

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

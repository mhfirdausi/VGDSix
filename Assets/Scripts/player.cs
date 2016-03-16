using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class player : MonoBehaviour {
    public static int points = 0;

    public static bool greenPower;
    public static bool redPower;
    public static bool bluePower;

    public static float speedDownTimer = 3.5f;
    public static float speedDownMult = .5f;
    public static float speedUpTimer = 3.5f;
    public static float speedUpMult = 2f;

    public static float blueBoxJump = 100f;


    public static float playerSpeed= 23.8095238095f;
    public static float jumpHeight = 70f;
    private Vector3 dir;

    public Rigidbody playerRigidBody;
    private bool isFalling = false;
    public int jumps;

    public float levelBottom = 25f;
    public UnityEvent onPlayerFall;

    void Start () {
        dir = Vector3.forward;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if (isFalling == false || jumps < 2)
            {
                playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpHeight, playerRigidBody.velocity.y);
                jumps++;
            }
        }
        isFalling = true;
	}

    void FixedUpdate()
    {
        float distanceToMove = playerSpeed * Time.deltaTime;
        transform.Translate(dir * distanceToMove);
        if(transform.position.y <= levelBottom)
        {
            onPlayerFall.Invoke();
            //TODO: Die, polished reset of the level
            transform.position = new Vector3(0f, 65f, -50f); //Set starting spawn position as constant?
        }
    }

    void OnCollisionStay()
    {
        isFalling = false;
        jumps = 0;
    } 

    void OnCollisionEnter(Collision other)
    {
        
    }
}

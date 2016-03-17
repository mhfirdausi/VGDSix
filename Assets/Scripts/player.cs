using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public float levelBottom = 30f;
    public UnityEvent onPlayerFall;
    public UnityEvent onPlayerQuit;

	public Canvas deathMenu;
	public Text countdown;

    void Start () {
        dir = Vector3.forward;
		deathMenu = deathMenu.GetComponent<Canvas> (); 
		deathMenu.enabled = false;
		countdown.enabled = false;
	}
	
	void Update () {

        //jetpack
        if (Input.GetKey("z"))
        {
            if (playerRigidBody.velocity.y < -.01)
            {
                playerRigidBody.velocity += playerRigidBody.transform.up * 9;
            }
            else
            {
                playerRigidBody.velocity += playerRigidBody.transform.up * 4;
            }
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && !(Input.GetKey("z")))
        {
           if (isFalling == false || jumps < 2)
            {
                playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpHeight, playerRigidBody.velocity.y);
                jumps++;
            }
        }
        //Temporary code to allow us to stop the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPlayerQuit.Invoke();
            SceneManager.LoadScene("Start");
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
			deathMenu.enabled = true;
			countdown.enabled = true;
			reload ();
            //transform.position = new Vector3(0f, 65f, -50f); //Set starting spawn position as constant?
        }
    }

	void reload() {
		StartCoroutine ("Wait");
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene ("Sport N Bass");
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

using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {
    Animator animator;

    public static int points = 0;
	public static int maxpoints;
	public Text pointsText;
	public Text pointsText2;
	public Text countdownText;

    public static float myLocationZ;

    public static bool greenPower;
    public static bool redPower;
    public static bool bluePower;

    public static float speedDownTimer = 1.5f;
    public static float speedDownMult = .5f;
    public static float speedUpTimer = 1.5f;
    public static float speedUpMult = 1.3f;

    public static float blueBoxJump = 100f;
    public float maxSpeed = 110f;


    public static float playerSpeed= 23.8095238095f;
    public static float jumpHeight = 70f;
    private Vector3 dir;

    public Rigidbody playerRigidBody;
    public bool isFalling = false;
    public int jumps;
    public static float heat;

    public Canvas deathMenu;
    public Text countdown;

    public float levelBottom = 30f;
    public UnityEvent onPlayerFall;
    public UnityEvent onPlayerQuit;

    void Start () {
        Time.timeScale = 1f;
        dir = Vector3.forward;
		deathMenu = deathMenu.GetComponent<Canvas> (); 
		deathMenu.enabled = false;
		countdown.enabled = false;

        heat = 0;
        playerSpeed = 23.8095238095f;

        animator = GameObject.Find("run").GetComponent<Animator>();
    }

    void Update() {

       
        

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
        

		//Points collection - Turner
		pointsText.text = "POINTS: " + points.ToString();
		pointsText2.text = "POINTS: " + points.ToString();
        
    }

    void FixedUpdate()
    {
        float distanceToMove = playerSpeed * Time.deltaTime;
        transform.Translate(dir * distanceToMove);
        if (transform.position.y <= levelBottom)
        {
            Debug.Log("Dead");
        }


        //anim stuff
        float yVel = playerRigidBody.velocity.y;
        animator.SetFloat("yVelocity", yVel);
        animator.SetBool("isFalling", isFalling);
        if (playerRigidBody.velocity.y < 0 || playerRigidBody.velocity.y > 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
        Debug.Log(playerRigidBody.velocity.y);
        

        //jetpack
        if (Input.GetKey("z") && heat < 100)
        {
            if (playerRigidBody.velocity.y < 0)
            {
                playerRigidBody.velocity = playerRigidBody.velocity + playerRigidBody.transform.up * 9f;
                heat = heat + 2;
            }
            else if (playerRigidBody.velocity.y >= 0)
            {
                playerRigidBody.velocity = playerRigidBody.velocity + playerRigidBody.transform.up * 5f;
                heat = heat + 2;
            }
            //Debug.Log("heat =" + heat);
        }
        if (!Input.GetKey("z") && heat >= 0)
        {
            heat = heat - .6f;
            //Debug.Log("heat =" + heat);
        }

        //cap speed
        if (playerRigidBody.velocity.magnitude > maxSpeed)
        {
            playerRigidBody.velocity = playerRigidBody.velocity.normalized * maxSpeed;
        }
        //Debug.Log(playerRigidBody.velocity.magnitude);
    }

	void reload() {
		StartCoroutine ("Wait");
		heat = 0;
		if (points > maxpoints) {
			points = maxpoints;
		}
		points = 0;
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene ("Sport N Bass");
	}


	//YES IT LOOKS STUPID, BUT IT WORKS.
	IEnumerator HailMary()
	{
		countdownText.text = "3";
		yield return new WaitForSeconds(1.2f);
		countdownText.text = "2";
		yield return new WaitForSeconds(1.2f);
		countdownText.text = "1";

	}

    void TriggerDeath()
    {
        onPlayerFall.Invoke();
        deathMenu.enabled = true;
        countdown.enabled = true;
        StartCoroutine("HailMary");
        reload();
    }

    void OnCollisionStay()
    {
        //isFalling = false;
        jumps = 0;
    } 

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathPlane")
        {
            TriggerDeath();
        }
    }
}

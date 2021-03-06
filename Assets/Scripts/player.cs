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
	public Text pointsAtDeath;

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
	public Canvas VictoryMenu;
    public Text countdown;

    public float levelBottom = 30f;
    public UnityEvent onPlayerFall;
    public UnityEvent onPlayerQuit;

    private AudioSource playerJumpSound;
    private Renderer[] playerRenders;
    private Material[] playerMaterials;
    private int sceneIndex;
    void Awake()
    {
        Time.timeScale = 1f;
        playerJumpSound = GetComponent<AudioSource>();
        points = 0;
        playerRenders = gameObject.GetComponentsInChildren<Renderer>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Start () {
        Time.timeScale = 1f;
        dir = Vector3.forward;
		deathMenu = deathMenu.GetComponent<Canvas> (); 
		deathMenu.enabled = false;
		countdown.enabled = false;
		VictoryMenu.enabled = false;

        heat = 0;
        playerSpeed = 23.8095238095f;

        animator = GameObject.Find("run").GetComponent<Animator>();
    }

    void Update() {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && !(Input.GetKey("z")))
        {
           if (isFalling == false || jumps < 1)
            {
                playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpHeight, playerRigidBody.velocity.y);
                jumps++;
                playerJumpSound.Play();
            }
        }

        
        //Temporary code to allow us to stop the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPlayerQuit.Invoke();
            SceneManager.LoadScene("Start");
        }
        

		//Points collection - Turner
		pointsText.text = points.ToString();
		pointsText2.text = points.ToString();
        
    }

    void FixedUpdate()
    {
        
        float distanceToMove = playerSpeed * Time.deltaTime;
        transform.Translate(dir * distanceToMove);

        //anim stuff
        float yVel = playerRigidBody.velocity.y;
        if (playerRigidBody.velocity.y < 0 || playerRigidBody.velocity.y > 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
        animator.SetFloat("yVelocity", yVel);
        animator.SetBool("isFalling", isFalling);

        //Debug.Log(playerRigidBody.velocity.y);
        

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
            heat = heat - .1f;
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
		heat = 0;
		if (points > maxpoints) {
			maxpoints = points;
		}
		StartCoroutine ("Wait");
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3.0f);
        if(sceneIndex == 4 )
        {
            SceneManager.LoadScene("Sport N Bass");
        }
		else if (sceneIndex == 5)
        {
            SceneManager.LoadScene("Sport N Bass chaos");
        }
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

	void onVictory()
	{
		VictoryMenu.enabled = true;
        Time.timeScale = 0f;
	}

    public void RenderRed()
    {
        foreach(Renderer r in playerRenders)
        {
            r.material.color = Color.red;
        }
    }

    public void RenderGreen()
    {
        foreach (Renderer r in playerRenders)
        {
            r.material.color = Color.green;
        }
    }

    public void RenderNormal()
    {
        foreach (Renderer r in playerRenders)
        {
            r.material.color = Color.white;
        }
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

		if (other.gameObject.name == "GoldCubeFlag")
		{
			onVictory();
            Debug.Log("victory here");
		}
    }
}

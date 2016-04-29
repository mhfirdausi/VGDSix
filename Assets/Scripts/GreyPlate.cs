using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GreyPlate : MonoBehaviour
{
    private bool speedChange = false;

    private float speedBoost;
    private float speedNerf;
    private float baseSpeed;

    public Rigidbody playerRigidBody;

    public AudioClip blueBlockSound;
    public AudioClip redBlockSound;
    public AudioClip greenBlockSound;

    private MusicLevelController musicController;
    private AudioSource graySoundSource;
    private Coroutine greyPlateCoroutine;
    private player currentPlayer;

    // Use this for initialization
    void Awake()
    {
        try
        {
            musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicLevelController>();
            baseSpeed = player.playerSpeed;
            speedBoost = player.playerSpeed * player.speedUpMult;
            speedNerf = player.playerSpeed * player.speedDownMult;
            playerRigidBody = GameObject.Find("playerCylinder").GetComponent<Rigidbody>();
            currentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
            graySoundSource = GetComponent<AudioSource>();
            graySoundSource.volume = 0.5f;
        }
        catch(System.NullReferenceException e)
        {
            Debug.LogError(e.Message);
        }
        catch(MissingReferenceException e)
        {
            Debug.Log(gameObject.name);
            Debug.LogError(e.Message);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speedChange == true && player.redPower == true && withinBounds())
        {
            player.playerSpeed = speedNerf;
            currentPlayer.RenderRed();
            if (greyPlateCoroutine != null)
                StopCoroutine(greyPlateCoroutine);
            greyPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSlowDown)
            {
                graySoundSource.clip = redBlockSound;
                if(!graySoundSource.isPlaying)
                {
                    graySoundSource.Play();
                }
                musicController.slowDownMusicEvent.Invoke();
            }
            //hitChangedToRed.Invoke();
        }
        else if (speedChange == true && player.greenPower == true && withinBounds())
        {
            player.playerSpeed = speedBoost;
            currentPlayer.RenderGreen();
            if (greyPlateCoroutine != null)
                StopCoroutine(greyPlateCoroutine);
            greyPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSpeedUp)
            {
                graySoundSource.clip = greenBlockSound;
                if (!graySoundSource.isPlaying)
                {
                    graySoundSource.Play();
                }
                musicController.speedUpMusicEvent.Invoke();
            }
            //hitChangedToGreen.Invoke();
        }
    }

    IEnumerator speedChangeTimerMethod()
    {
        yield return new WaitForSeconds(player.speedUpTimer);
        speedChangeUndo();
    }

    void speedChangeUndo()
    {
        speedChange = false;
        currentPlayer.RenderNormal();
        player.playerSpeed = baseSpeed;
        if (musicController.canResumeNormal)
        {
            musicController.playNormalMusicEvent.Invoke();
        }
        //resumeNormal.Invoke();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && player.bluePower == true && withinBounds() == true)
        {
            graySoundSource.clip = blueBlockSound;
            if(!graySoundSource.isPlaying)
            {
                graySoundSource.Play();
            }
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.z);
        }
        else if (other.gameObject.CompareTag("Player") && (player.greenPower == true || player.redPower == true))
        {
            speedChange = true;
        }
        else
        {
            graySoundSource.clip = null;
        }
    }

    public bool withinBounds()
    {
        if ((transform.position.z > player.myLocationZ - 60) && (transform.position.z < player.myLocationZ + 60))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
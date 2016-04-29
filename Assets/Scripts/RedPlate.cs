using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class RedPlate : MonoBehaviour
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
    private Coroutine redPlateCoroutine;
    private AudioSource redSoundSource;
    private player currentPlayer;

    void Awake()
    {
        baseSpeed = player.playerSpeed;
        speedBoost = player.playerSpeed * player.speedUpMult;
        speedNerf = player.playerSpeed * player.speedDownMult;
        try
        {
            musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicLevelController>();
            playerRigidBody = GameObject.Find("playerCylinder").GetComponent<Rigidbody>();
            currentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
            redSoundSource = GetComponent<AudioSource>();
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError(e.Message);
        }

    }

    void FixedUpdate()
    {
        if (speedChange == true && player.greenPower == true && withinBounds())
        {
            player.playerSpeed = speedBoost;
            currentPlayer.RenderGreen();
            if (redPlateCoroutine != null)
                StopCoroutine(redPlateCoroutine);
            redPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSpeedUp)
            {
                redSoundSource.clip = greenBlockSound;
                if (!redSoundSource.isPlaying)
                {
                    redSoundSource.Play();
                }
                musicController.speedUpMusicEvent.Invoke();
            }
                
        }
        else if (speedChange == true)
        {
            player.playerSpeed = speedNerf;
            currentPlayer.RenderRed();
            redPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSlowDown)
            {
                redSoundSource.clip = redBlockSound;
                if (!redSoundSource.isPlaying)
                {
                    redSoundSource.Play();
                }
                musicController.slowDownMusicEvent.Invoke();
            }
        }
    }


    IEnumerator speedChangeTimerMethod()
    {
        yield return new WaitForSeconds(player.speedDownTimer);
        speedChangeUndo();
    }

    void speedChangeUndo()
    {
        currentPlayer.RenderNormal();
        speedChange = false;
        player.playerSpeed = baseSpeed;
        if (musicController.canResumeNormal)
            musicController.playNormalMusicEvent.Invoke();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && player.bluePower == true && withinBounds())
        {
            redSoundSource.clip = blueBlockSound;
            if (!redSoundSource.isPlaying)
            {
                redSoundSource.Play();
            }
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.y);
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            speedChange = true;
        }
        else
        {
            redSoundSource.clip = redBlockSound;
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

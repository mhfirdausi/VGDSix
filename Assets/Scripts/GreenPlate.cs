using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GreenPlate : MonoBehaviour
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
    private AudioSource greenSoundSource;
    private Coroutine greenPlateCoroutine;
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
            greenSoundSource = GetComponent<AudioSource>();
            greenSoundSource.volume = 0.5f;
        }
        catch (System.NullReferenceException e)
        {
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
            if (greenPlateCoroutine != null)
                StopCoroutine(greenPlateCoroutine);
            greenPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSlowDown)
            {
                greenSoundSource.clip = redBlockSound;
                if(!greenSoundSource.isPlaying)
                {
                    greenSoundSource.Play();
                }
                musicController.slowDownMusicEvent.Invoke();
            }
                
        }
        else if (speedChange == true)
        {
            player.playerSpeed = speedBoost;
            currentPlayer.RenderGreen();
            greenPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSpeedUp)
            {
                greenSoundSource.clip = greenBlockSound;
                if(!greenSoundSource.isPlaying)
                {
                    greenSoundSource.Play();
                }
                musicController.speedUpMusicEvent.Invoke();
            }
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
            musicController.playNormalMusicEvent.Invoke();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && player.bluePower == true && withinBounds())
        {
            greenSoundSource.clip = blueBlockSound;
            if(!greenSoundSource.isPlaying)
            {
                greenSoundSource.Play();
            }
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.z);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            speedChange = true;
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

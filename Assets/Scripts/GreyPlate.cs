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

    private MusicLevelController musicController;

    private Coroutine greyPlateCoroutine;

    // Use this for initialization
    void Awake()
    {
        baseSpeed = player.playerSpeed;
        speedBoost = player.playerSpeed * player.speedUpMult;
        speedNerf = player.playerSpeed * player.speedDownMult;
        playerRigidBody = GameObject.Find("playerCylinder").GetComponent<Rigidbody>();
        try
        {
            musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicLevelController>();
        }
        catch(System.NullReferenceException e)
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
            if (greyPlateCoroutine != null)
                StopCoroutine(greyPlateCoroutine);
            greyPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if(musicController.canSlowDown)
                musicController.slowDownMusicEvent.Invoke();
            //hitChangedToRed.Invoke();
        }
        else if (speedChange == true && player.greenPower == true && withinBounds())
        {
            player.playerSpeed = speedBoost;
            if (greyPlateCoroutine != null)
                StopCoroutine(greyPlateCoroutine);
            greyPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if(musicController.canSpeedUp)
                musicController.speedUpMusicEvent.Invoke();
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
        player.playerSpeed = baseSpeed;
        if(musicController.canResumeNormal)
            musicController.playNormalMusicEvent.Invoke();
        //resumeNormal.Invoke();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && player.bluePower == true && withinBounds() == true)
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.z);
        }
        else if (other.gameObject.CompareTag("Player") && (player.greenPower == true || player.redPower == true))
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
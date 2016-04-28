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

    private MusicLevelController musicController;

    private Coroutine redPlateCoroutine;

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
            if (redPlateCoroutine != null)
                StopCoroutine(redPlateCoroutine);
            redPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSpeedUp)
                musicController.speedUpMusicEvent.Invoke();
        }
        else if (speedChange == true)
        {
            player.playerSpeed = speedNerf;
            redPlateCoroutine = StartCoroutine(speedChangeTimerMethod());
            if (musicController.canSlowDown)
                musicController.slowDownMusicEvent.Invoke();
        }
    }


    IEnumerator speedChangeTimerMethod()
    {
        yield return new WaitForSeconds(player.speedDownTimer);
        speedChangeUndo();
    }

    void speedChangeUndo()
    {
        speedChange = false;
        player.playerSpeed = baseSpeed;
        if (musicController.canResumeNormal)
            musicController.playNormalMusicEvent.Invoke();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && player.bluePower == true && withinBounds())
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.y);
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

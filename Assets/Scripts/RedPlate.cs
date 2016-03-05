using UnityEngine;
using System.Collections;

public class RedPlate : MonoBehaviour
{

    private bool speedChange = false;
    
    private float speedBoost;
    private float speedNerf;
    private float baseSpeed;

    public Rigidbody playerRigidBody;

    // Use this for initialization
    void Awake()
    {
        baseSpeed = player.playerSpeed;
        speedBoost = player.playerSpeed * player.speedUpMult;
        speedNerf = player.playerSpeed * player.speedDownMult;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speedChange == true && player.greenPower == true)
        {
            player.playerSpeed = speedBoost;
            StartCoroutine(speedChangeTimerMethod());
        }
        else if (speedChange == true)
        {
            player.playerSpeed = speedNerf;
            StartCoroutine(speedChangeTimerMethod());
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
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && player.bluePower == true)
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.y);
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            speedChange = true;
        }
    }

}

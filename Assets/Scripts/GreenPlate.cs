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

    public UnityEvent hitChangedToRed;
    public UnityEvent hitGreenBlock;
    public UnityEvent resumeNormal;

    // Use this for initialization
    void Awake()
    {
        baseSpeed = player.playerSpeed;
        speedBoost = player.playerSpeed * player.speedUpMult;
        speedNerf = player.playerSpeed * player.speedDownMult;
        playerRigidBody = GameObject.Find("playerCylinder").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speedChange == true && player.redPower == true && withinBounds())
        {
            player.playerSpeed = speedNerf;
            StartCoroutine(speedChangeTimerMethod());
            hitChangedToRed.Invoke();
        }
        else if (speedChange == true)
        {
            player.playerSpeed = speedBoost;
            StartCoroutine(speedChangeTimerMethod());
            hitGreenBlock.Invoke();
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
        resumeNormal.Invoke();
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

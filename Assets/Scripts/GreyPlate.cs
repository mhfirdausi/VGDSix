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

    public UnityEvent hitChangedToRed;
    public UnityEvent hitChangedToGreen;
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
        if (speedChange == true && player.redPower == true)
        {
            player.playerSpeed = speedNerf;
            StartCoroutine(speedChangeTimerMethod());
            hitChangedToRed.Invoke();
        }
        else if (speedChange == true && player.greenPower == true)
        {
            Debug.Log("speedchange");
            player.playerSpeed = speedBoost;
            StartCoroutine(speedChangeTimerMethod());
            hitChangedToGreen.Invoke();
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
        if (other.gameObject.CompareTag("Player") && player.bluePower == true)
        {
            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, player.blueBoxJump, playerRigidBody.velocity.y);
        }
        else if (other.gameObject.CompareTag("Player") && (player.greenPower == true || player.redPower == true))
        {
            speedChange = true;
        }
    }

    /*
    bool inBounds()
    {
        if (GameObject.Find("playerCylinder").transform.position.y < (10));
        return true;
    }
    */
}
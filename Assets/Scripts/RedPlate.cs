using UnityEngine;
using System.Collections;

public class RedPlate : MonoBehaviour
{

    private bool speedUp = false;
    public float speedUpTimer = 3.5f;
    public float speedUpMult = .5f;
    private float speedBoost;
    private float baseSpeed;


    // Use this for initialization
    void Awake()
    {
        baseSpeed = player.playerSpeed;
        speedBoost = player.playerSpeed * speedUpMult;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speedUp == true)
        {
            player.playerSpeed = speedBoost;
            StartCoroutine(speedUpTimerMethod());
        }
    }


    IEnumerator speedUpTimerMethod()
    {
        yield return new WaitForSeconds(speedUpTimer);
        speedUpUndo();
    }

    void speedUpUndo()
    {
        speedUp = false;
        player.playerSpeed = baseSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speedUp = true;
        }
    }

}

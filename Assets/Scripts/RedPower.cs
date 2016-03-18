using UnityEngine;
using System.Collections;

public class RedPower : MonoBehaviour {
    public int redPowerTimer = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.redPower == true)
        {
            StartCoroutine(redPowerTimerMethod());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.redPower = true;
            player.greenPower = false;
            player.bluePower = false;
        }
    }

    IEnumerator redPowerTimerMethod()
    {
        yield return new WaitForSeconds(redPowerTimer);
        redPowerUndo();
    }

    void redPowerUndo()
    {
        player.redPower = false;
    }

}

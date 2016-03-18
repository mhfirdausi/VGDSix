using UnityEngine;
using System.Collections;

public class BluePower : MonoBehaviour {
    public int bluePowerTimer = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.bluePower == true)
        {
            StartCoroutine(bluePowerTimerMethod());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.bluePower = true;
            player.greenPower = false;
            player.redPower = false;
        }
    }

    IEnumerator bluePowerTimerMethod()
    {
        yield return new WaitForSeconds(bluePowerTimer);
        bluePowerUndo();
    }

    void bluePowerUndo()
    {
        player.bluePower = false;
    }

}

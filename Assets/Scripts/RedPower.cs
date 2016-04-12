using UnityEngine;
using System.Collections;

public class RedPower : MonoBehaviour {
    public static int redPowerTimer = 3;
    public static bool routinerunning = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.redPower == true && routinerunning == false)
        {
            StartCoroutine(redPowerTimerMethod());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine("redPowerTimer");

            player.redPower = true;
            player.greenPower = false;
            player.bluePower = false;

            //forgive the spaghetti, the below has to do with powerups effecting blocks within a z range.
            player.myLocationZ = GameObject.Find("playerCylinder").transform.position.z;
        }
    }

    IEnumerator redPowerTimerMethod()
    {
        routinerunning = true;
        yield return new WaitForSeconds(redPowerTimer);
        redPowerUndo();
    }

    void redPowerUndo()
    {
        routinerunning = false;
        player.redPower = false;
    }

}

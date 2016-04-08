using UnityEngine;
using System.Collections;

public class RedPower : MonoBehaviour {
    public int redPowerTimer = 3;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.redPower = true;
            player.greenPower = false;
            player.bluePower = false;

            //forgive the spaghetti, the below has to do with powerups effecting blocks within a z range.
            player.myLocationZ = GameObject.Find("playerCylinder").transform.position.z;
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

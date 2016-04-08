using UnityEngine;
using System.Collections;

public class GreenPower : MonoBehaviour {
    public int greenPowerTimer=3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (player.greenPower == true)
        {
            StartCoroutine(greenPowerTimerMethod());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.greenPower = true;
            player.redPower = false;
            player.bluePower = false;

            //forgive the spaghetti, the below has to do with powerups effecting blocks within a z range.
            player.myLocationZ = GameObject.Find("playerCylinder").transform.position.z;
        }
    }

    IEnumerator greenPowerTimerMethod()
    {
        yield return new WaitForSeconds(greenPowerTimer);
        greenPowerUndo();
    }

    void greenPowerUndo()
    {
        player.greenPower = false;
    }

}

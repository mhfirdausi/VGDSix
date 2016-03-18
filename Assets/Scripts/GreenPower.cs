using UnityEngine;
using System.Collections;

public class GreenPower : MonoBehaviour {
    public int greenPowerTimer=5;

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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.greenPower = true;
            player.redPower = false;
            player.bluePower = false;
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

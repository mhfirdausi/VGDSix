using UnityEngine;
using System.Collections;

public class GreenPower : MonoBehaviour {
    public static int greenPowerTimer = 3;
    public static bool routinerunning = false;

    public float speed = 20f;

    private Coroutine greenCoroutine;
    private AudioSource greenSound;
    void Awake()
    {
        greenSound = GetComponent<AudioSource>();
        greenSound.volume = 0.25f;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.greenPower && !routinerunning)
        {
            greenCoroutine = StartCoroutine(greenPowerTimerMethod());
        }
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (greenCoroutine != null)
                StopCoroutine(greenCoroutine);

            player.greenPower = true;
            player.redPower = false;
            player.bluePower = false;

            //forgive the spaghetti, the below has to do with powerups effecting blocks within a z range.
            player.myLocationZ = GameObject.Find("playerCylinder").transform.position.z;
            this.GetComponent<Renderer>().enabled = false;
            greenSound.Play();
        }
    }

    IEnumerator greenPowerTimerMethod()
    {
        routinerunning = true;
        yield return new WaitForSeconds(greenPowerTimer);
        greenPowerUndo();
    }

    void greenPowerUndo()
    {
        routinerunning = false;
        player.greenPower = false;
    }

}

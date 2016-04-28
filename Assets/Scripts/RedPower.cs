using UnityEngine;
using System.Collections;

public class RedPower : MonoBehaviour {
    public static int redPowerTimer = 3;
    public static bool routinerunning = false;

    public float speed = 20f;

    private Coroutine redCoroutine;
    private AudioSource redSound;

    void Awake()
    {
        redSound = GetComponent<AudioSource>();
        redSound.volume = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.redPower == true && routinerunning == false)
        {
            redCoroutine = StartCoroutine(redPowerTimerMethod());
        }
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (redCoroutine != null)
                StopCoroutine(redCoroutine);

            player.redPower = true;
            player.greenPower = false;
            player.bluePower = false;

            //forgive the spaghetti, the below has to do with powerups effecting blocks within a z range.
            player.myLocationZ = GameObject.Find("playerCylinder").transform.position.z;
            this.GetComponent<Renderer>().enabled = false;
            redSound.Play();
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

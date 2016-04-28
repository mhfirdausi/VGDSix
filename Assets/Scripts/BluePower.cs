using UnityEngine;
using System.Collections;

public class BluePower : MonoBehaviour {
   public static int bluePowerTimer = 3;
   public static bool routinerunning = false;

    public float speed = 20f;
    private Coroutine blueCoroutine;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bluePower == true && routinerunning == false)
        {
            blueCoroutine = StartCoroutine(bluePowerTimerMethod());
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
            if (blueCoroutine != null) 
                StopCoroutine(blueCoroutine);
       
            player.bluePower = true;
            player.greenPower = false;
            player.redPower = false;

            //forgive the spaghetti, the below has to do with powerups effecting blocks within a z range.
            player.myLocationZ = GameObject.Find("playerCylinder").transform.position.z;
            this.GetComponent<Renderer>().enabled = false;
        }
    }

    public static IEnumerator bluePowerTimerMethod()
    {
        routinerunning = true;
        yield return new WaitForSeconds(bluePowerTimer);
        bluePowerUndo();
    }

    public static void bluePowerUndo()
    {
        routinerunning = false;
        player.bluePower = false;
    }

}

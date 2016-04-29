using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomCube : MonoBehaviour {


    public GameObject neutral;
    public GameObject slow;
    public GameObject speed;
    public GameObject bounce;
    public GameObject player;
    private int x;
    private float timer;
    private bool canSwitch;
    void Awake()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index != 5)
        {
            Destroy(this);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        timer = 0;
        canSwitch = true;
        Vector3 x = player.transform.position;
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        if (timer > 5 && canSwitch)
        {
            if (player.transform.position.z + 40f >= transform.position.z && player.transform.position.z - transform.position.z < 20f) {
                x = Random.Range(0, 100);
                Debug.Log("Z: " + transform.position.z + ", x: " + x);
                if (x < 7)
                {
                    GameObject obj = (GameObject)Instantiate(slow, transform.position, transform.rotation);
                    Destroy(gameObject);

                }
                else if (x < 14)
                {
                    GameObject obj = (GameObject)Instantiate(speed, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                else if (x < 28)
                {
                    GameObject obj = (GameObject)Instantiate(bounce, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                canSwitch = false;
            }
            timer = 0;
        }
}
}


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

    void Awake()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index != 5)
        {
            Destroy(this);
        }
    }
    void Start()
    {
        timer = 0;
        Vector3 x = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 5)
        {
            if (this.transform.position.z-10<=player.transform.position.z||this.transform.position.z+10>=player.transform.position.z) { 
                x = UnityEngine.Random.Range(0, 10);
                if (x == 1)
                {
                    GameObject obj = (GameObject)Instantiate(slow, neutral.transform.position, neutral.transform.rotation);
                    Destroy(neutral);
                    
                }
                else if (x == 2)
                {
                    GameObject obj = (GameObject)Instantiate(speed, neutral.transform.position, neutral.transform.rotation);
                    Destroy(neutral);
                                    }
                else if (x == 3)
                {
                    GameObject obj = (GameObject)Instantiate(bounce, neutral.transform.position, neutral.transform.rotation);
                    Destroy(neutral);
                    

                }
                timer = 0;
            }
        }
}
}


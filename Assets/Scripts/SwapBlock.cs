using UnityEngine;
using System.Collections;
using System;


public class SwapBlock : MonoBehaviour {

    public GameObject neutral;
    public GameObject slow;
    public GameObject speed;
    public GameObject bounce;

    public static Queue blocks;
    private int cube;
    public int number;
	public int next;

    void Start()
    {
        blocks = new Queue();

    }

    void Update()
    {
        if (blocks.Count < 1)
        {
            number = UnityEngine.Random.Range(0, 3);
            blocks.Enqueue(number);

        }

    }
		

    void OnMouseDown()
    {
        if (blocks.Peek().Equals(0))
        {
			blocks.Dequeue();
            GameObject obj = (GameObject)Instantiate(slow, neutral.transform.position, neutral.transform.rotation);
            Destroy(neutral);
        }
        else if (blocks.Peek().Equals(1))
        {
            blocks.Dequeue();
            GameObject obj = (GameObject)Instantiate(speed, neutral.transform.position, neutral.transform.rotation);
            Destroy(neutral);
        }
        else
        {
            blocks.Dequeue();
            GameObject obj = (GameObject)Instantiate(bounce, neutral.transform.position, neutral.transform.rotation);
            Destroy(neutral);

        }
    }
		

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class SwapBlock : MonoBehaviour {

    public GameObject neutral;
    public GameObject slow;
    public GameObject speed;
    public GameObject bounce;
	public Sprite red;
	public Sprite blue;
	public Sprite green;
	public Sprite lblue;
	public Image basic;
    public static Queue blocks;
    private int cube;
    public int number;
	public int next;

    void Start()
    {
        blocks = new Queue();
        if(gameObject.GetComponent<Image>() != null)
            basic = basic.GetComponent<Image>();
    }

    void Update()
    {
        if (blocks.Count < 1)
        {
            number = UnityEngine.Random.Range(0, 3);
            blocks.Enqueue(number);
			QueueIE ();
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

	//Block queue.
	void QueueIE() 
	{
        Debug.Log("Queue: " + blocks.Peek());
        if (blocks.Peek().Equals(0)) 
		{
			basic.sprite = red;
		} 
		else if (blocks.Peek().Equals(1)) 
		{
			basic.sprite = green;
		} 
		else 
		{
			basic.sprite = blue;
		}
	}
}

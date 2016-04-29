using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QueueUI : MonoBehaviour {

	public Sprite red;
	public Sprite blue;
	public Sprite green;
	public Sprite lblue;
	public Image basic;

	void Start () {
		if(gameObject.GetComponent<Image>() != null)
			basic = basic.GetComponent<Image>();
	
	}

	void Update () {
		QueueIE ();
	}

	void QueueIE() 
	{
		if (SwapBlock.blocks.Peek().Equals(0)) 
		{
			basic.sprite = red;
		} 
		else if (SwapBlock.blocks.Peek().Equals(1)) 
		{
			basic.sprite = green;
		} 
		else 
		{
			basic.sprite = blue;
		}
	}
}

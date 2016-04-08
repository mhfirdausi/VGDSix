using UnityEngine;
using System.Collections;

public class animator : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (player.isFalling == true)
        {
            anim.SetBool("imFalling", true);

        }
        if (player.isFalling == false)
        {
            anim.SetBool("imFalling", false);
        }
    }
}

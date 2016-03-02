using UnityEngine;
using System.Collections;

public class RedBlock : MonoBehaviour {
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (player.greenPower == true)
        {
            GetComponent<Renderer>().material = greenMaterial;
        }
        else if (player.bluePower == true)
        {
            GetComponent<Renderer>().material = blueMaterial;
        }
        else
            GetComponent<Renderer>().material = redMaterial;
	}
}

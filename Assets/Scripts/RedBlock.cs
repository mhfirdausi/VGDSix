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
        if (player.greenPower == true && withinBounds())
        {
            GetComponent<Renderer>().material = greenMaterial;
        }
        else if (player.bluePower == true && withinBounds())
        {
            GetComponent<Renderer>().material = blueMaterial;
        }
        else
            GetComponent<Renderer>().material = redMaterial;
	}

    public bool withinBounds()
    {
        if ((transform.position.z > player.myLocationZ - 60) && (transform.position.z < player.myLocationZ + 60))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

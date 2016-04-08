using UnityEngine;
using System.Collections;

public class GreenBlock : MonoBehaviour {
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.redPower == true && withinBounds())
        {
            GetComponent<Renderer>().material = redMaterial;
        }
        else if (player.bluePower == true && withinBounds())
        {
            GetComponent<Renderer>().material = blueMaterial;
        }
        else
            GetComponent<Renderer>().material = greenMaterial;
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
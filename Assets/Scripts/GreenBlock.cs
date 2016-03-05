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
        if (player.redPower == true)
        {
            GetComponent<Renderer>().material = redMaterial;
        }
        else if (player.bluePower == true)
        {
            GetComponent<Renderer>().material = blueMaterial;
        }
        else
            GetComponent<Renderer>().material = greenMaterial;
    }
}
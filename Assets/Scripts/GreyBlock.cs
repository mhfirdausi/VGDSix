using UnityEngine;
using System.Collections;

public class GreyBlock : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    public Material greyMaterial;


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
        else if (player.greenPower == true)
        {
            GetComponent<Renderer>().material = greenMaterial;
        }
        else
            GetComponent<Renderer>().material = greyMaterial;
    }
}
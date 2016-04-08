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
        if (player.redPower == true && withinBounds())
        {
            GetComponent<Renderer>().material = redMaterial;
        }
        else if (player.bluePower == true && withinBounds() == true)
        {
            GetComponent<Renderer>().material = blueMaterial;
        }
        else if (player.greenPower == true && withinBounds())
        {
            GetComponent<Renderer>().material = greenMaterial;
        }
        else
            GetComponent<Renderer>().material = greyMaterial;
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
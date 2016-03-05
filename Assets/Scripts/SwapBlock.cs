using UnityEngine;
using System.Collections;
using System;

public class SwapBlock : MonoBehaviour {

   public GameObject neutral;
   public GameObject slow;
   public GameObject speed;
   public GameObject bounce;
   private int cube;
    
    void OnMouseDown()
    {
        cube=UnityEngine.Random.Range(0, 3);
        if (cube == 0)
        {
            

                GameObject obj = (GameObject)Instantiate(slow, neutral.transform.position, neutral.transform.rotation);
                Destroy(neutral);

            
        }
        else if (cube == 1)
        {
            

                GameObject obj = (GameObject)Instantiate(speed, neutral.transform.position, neutral.transform.rotation);
                Destroy(neutral);

            
        }
        else
        {
           

                GameObject obj = (GameObject)Instantiate(bounce, neutral.transform.position, neutral.transform.rotation);
                Destroy(neutral);

            
        }
        
    }

}

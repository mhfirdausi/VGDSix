using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour {

	
    void Awake()
    {
        float randomValue = Random.value;
        if(randomValue <= .5f)
        {
            //Debug.Log("Spawn cassette! " + randomValue);
            Instantiate(Resources.Load("Cassette"), transform.position + new Vector3(0, 5f), transform.rotation);
        }
        else if (randomValue >= .94f)
        {
            if (randomValue <= .96f)
            {
                //Debug.Log("Spawn blue powerup!" + randomValue);
                Instantiate(Resources.Load("BluePower"), transform.position + new Vector3(0, 5f), Quaternion.Euler(90f, 0, 0));
            }
            else if (randomValue <= .98f)
            {
                //Debug.Log("Spawn red powerup!" + randomValue);
                Instantiate(Resources.Load("RedPower"), transform.position + new Vector3(0, 5f), Quaternion.Euler(90f, 0, 0));
            }
            else if (randomValue <= 1f)
            {
                //Debug.Log("Spawn green powerup!" + randomValue);
                Instantiate(Resources.Load("GreenPower"), transform.position + new Vector3(0, 5f), Quaternion.Euler(90f, 0, 0));
            }

        } 
    }
	
}

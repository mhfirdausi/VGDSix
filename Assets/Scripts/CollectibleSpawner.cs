using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour {

	
    void Awake()
    {
        int neighborCount = 0;
        //TODO: Allow this to work for any level!
        if (transform.position.z < 50f)
        {
            return;
        }
        Collider[] count = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider c in count)
        {
            //Should a powerup be spawned if there is a colored cube already in the row?
            if (c.gameObject.tag == "NeutralCube" && c.gameObject.name != this.name)
            {
                neighborCount++;
            }
        }
        float randomValue = Random.value;
        if(randomValue <= .5f)
        {
            //Debug.Log("Spawn cassette! " + randomValue);
            Instantiate(Resources.Load("Cassette"), transform.position + new Vector3(0, 5f), transform.rotation);
        }
        else if (randomValue >= .82f && neighborCount > 1)
        {
            if (randomValue <= .88f)
            {
                //Debug.Log("Spawn blue powerup!" + randomValue);
                Instantiate(Resources.Load("BluePower"), transform.position + new Vector3(0, 5f), Quaternion.Euler(90f, 0, 0));
            }
            else if (randomValue <= .94f)
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

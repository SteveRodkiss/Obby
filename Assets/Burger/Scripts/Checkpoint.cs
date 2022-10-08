using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //variables
    Vector3 rotationSpeed = new Vector3(0, 90, 0);
    
    // Update is called once per frame
    void Update()
    {
        //spin around
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //fires when an object enters the trigger
        if (other.tag == "Player")
        {
            //player entered area
            other.GetComponent<PlayerRespawn>().SetNewRespawnPosition(transform.position);
            Destroy(gameObject);
        }
    }

}

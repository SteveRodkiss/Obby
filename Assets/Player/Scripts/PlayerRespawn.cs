using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    Vector3 startPosition = Vector3.zero;
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if we fall below a certain y position, respawn us
        if (transform.position.y < -10f)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        cc.enabled = false;
        transform.position = startPosition;
        cc.enabled = true;
    }


    public void SetNewRespawnPosition(Vector3 newPosition)
    {
        startPosition = newPosition;
    }
}

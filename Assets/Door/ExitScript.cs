using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{

    int currentSceneNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get current scene number
        currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //player toucher the door- load the next scene
            SceneManager.LoadScene(currentSceneNumber + 1);
        }
    }

}

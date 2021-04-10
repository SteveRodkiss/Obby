using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 controllerInput = Vector3.zero;

    float gravity = 20f;
    float yVelocity = 0f;
    //the movement speed
    float moveSpeed = 5f;
    //jympspeed
    float jumpSpeed = 12f;
    //the animator
    public Animator animator;
    //the camera so it you can move relative to the camera direction
    Transform cameraTransform;



    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        controllerInput.x = Input.GetAxis("Horizontal");
        controllerInput.z = Input.GetAxis("Vertical");
        //set the animator speed variable to be equal to the magnitude of the input
        animator.SetFloat("speed", controllerInput.magnitude);


        //controller input clamped to 1.
        controllerInput = Vector3.ClampMagnitude(controllerInput, 1f) * moveSpeed;
        //make it fall
        yVelocity -= gravity * Time.deltaTime;
        if (cc.isGrounded)
        {
            yVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("jump");
                yVelocity = jumpSpeed;
            }
        }
        //now the move vector
        //first rotate the move vector relative to the camera
        Vector3 moveDirection = Quaternion.LookRotation(GetCameraForward()) * controllerInput;
        //then add in the yvelocity and scale it for frame rate
        Vector3 move = new Vector3(moveDirection.x, yVelocity, moveDirection.z) * Time.deltaTime;
        //and move
        cc.Move(move);

        //turn to face the direction we are moving in
        if (controllerInput.sqrMagnitude > 0.05f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), 360f * Time.deltaTime);
        }
    }


    Vector3 GetCameraForward()
    {
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        return camForward.normalized;
    }

}

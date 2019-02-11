using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitMovePlayer : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            // Player is on the ground
            verticalVelocity = -0.5f;
        }
        else
        {
            // PlayerMotor is KeyNotFoundException on the ground
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // X - Left Right movement
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // Y - Up Down movement
        moveVector.y = verticalVelocity;

        // Z - Forward Backword movement
        moveVector.z = speed;


        controller.Move(moveVector * Time.deltaTime);
    }
}

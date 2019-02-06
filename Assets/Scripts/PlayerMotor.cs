using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveVector = Vector3.zero;

        // X (left - right)
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // Y (up - down)

        // Z (forward - backward)
        moveVector.z =  Input.GetAxisRaw("Vertical") * speed;

        controller.Move(moveVector * speed * Time.deltaTime);
    }
}

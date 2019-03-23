using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.SceneManagement;

public class RohitMovePlayer : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public GameObject capsule;
    private CharacterController controller;
    private float speed = 5.0f;
    private float horizontalSpeed = 2.5f;
    private float speedMultiplier = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    public Boolean isDead = false;
    private float animationDuration = 3;
    private Boolean isSphere = false;
    private Boolean isCube = false;
    private CultureInfo ci= new CultureInfo("en-US");
    private Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        capsule.SetActive(true);
        sphere.SetActive(false);
        cube.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (isSphere)
        {
            sphere.SetActive(true);
            cube.SetActive(false);
            capsule.SetActive(false);
        }
        if (isCube)
        {
            sphere.SetActive(false);
            cube.SetActive(true);
            capsule.SetActive(false);
        }
        if (isDead)
        {
            Debug.Log("MovePlayer: Is Dead");
            return;
        }
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
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
        moveVector.x = Input.GetAxisRaw("Horizontal") * horizontalSpeed;

        // Y - Up Down movement
        moveVector.y = verticalVelocity;

        // Z - Forward Backword movement
        moveVector.z = speed;
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime * 1.9f);

        controller.Move(moveVector * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Death();
        }

        

    }


    // On collider hit
    // Called every time our player collides with any object
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((!hit.gameObject.name.StartsWith("Tile", true, ci)) && HitCheckAllDirections(hit))
        {
            Debug.Log("Collided with: " + hit.gameObject.name);

            if (hit.gameObject.name == "Obstacle_Sphere(Clone)")
            {
                // Sphere hit
                GetComponent<RohitPlayerState>().CyclePowerUp();
                Debug.Log("in health reduction if");
                Destroy(hit.gameObject);
                // health computation
                GetComponent<RohitHealthCalculation>().OnHealthReduce();
                isSphere = true;
                isCube = false;

            }
            else if (hit.gameObject.name == "Obstacle_Cube(Clone)")
            {
                // Cube hit
                GetComponent<RohitPlayerState>().SkatePowerUp();
                Destroy(hit.gameObject);
                isCube = true;
                isSphere = false;
            }
            else
            {
                Death();
            }
        }

    }

    private void Death()
    {
        isDead = true;
        GetComponent<RohitScoresCalculations>().OnDeathScoreStops();
    }

    public void IncreaseSpeedByVal(int difficultLevel)
    {
        speed = difficultLevel * speedMultiplier;
    }

    public void UpdateSpeedByPowerup(float levelSpeed)
    {
        speed = levelSpeed;
    }

    private bool HitCheckAllDirections(ControllerColliderHit hit)
    {
        return ((hit.point.z > transform.position.z + 0.01f) ||
                (hit.point.z < transform.position.z - 0.01f) ||
                (hit.point.x > transform.position.x + 0.01f) || 
                (hit.point.x < transform.position.x - 0.01f) || 
                (hit.point.y > transform.position.y + 0.01f) ||
                (hit.point.y < transform.position.y - 0.01f));
    }
    public void onReset()
    {
        SceneManager.LoadScene(0);

    }
    public void onJump()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;
        
            moveDirection.y = jumpSpeed;
            controller.Move(moveDirection * Time.deltaTime*1.9f);
        
    }

}

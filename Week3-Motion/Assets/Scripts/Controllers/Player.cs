using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //Veriables for Task 1A
    public Vector3 velocity;


    //Veriables for Task 1B
    public float maxSpeed = 3;
    public float accesleration;
    public float accelerationTime;

    //Variables for Task 1C
    public float decelortion;
    public float decelortionTime; 

    public void Start()
    {
        //Task 1B
        accesleration = maxSpeed / accelerationTime;

        //Task 1C
        decelortion = maxSpeed * decelortionTime;
    }


    void Update()
    {

        PlayerMovement();
    }

    public void PlayerMovement()
    {
        //Task 1A
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //velocity = new Vector3 (horizontalInput, verticalInput);
        //transform.position = transform.position + velocity;

        //Task 1B
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");   
        velocity += new Vector3( horizontalInput, verticalInput ) * accesleration * Time.deltaTime ;
        transform.position = transform.position + velocity ;

        if(accesleration == maxSpeed)
        {
        Debug.Log("MAXREACHED");
        }

        //Task 1C
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //velocity += new Vector3(horizontalInput, verticalInput) * decelortion * Time.deltaTime;
        //transform.position = transform.position + velocity;

    }

}

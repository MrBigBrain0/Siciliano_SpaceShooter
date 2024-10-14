using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    // veriables For final Assingment Task 3
    public Transform blackHole;
    public Transform blackHole2;
    public Transform blackHole3;
    public Transform blackHole4;
    public Transform blackHoleRadius;
    public Transform blackHoleRadius2;
    public Transform blackHoleRadius3;
    public Transform blackHoleRadius4;
    public float blackRad;
    public float blackRad2;

    //Veriables for Task 1A
    Vector3 velocity;


    //Veriables for Task 1B
    public float maxSpeed ;
    public float accesleration;
    public float accelerationTime;

    //Variables for Task 1C
    public float decelortion;
    public float decelortionTime;

    //Variables for week 4

    //size of the radar
    public float radius = 0f;
    //number of points the radius has
    public int circlePoints = 6;
    //Number of power ups
    public int numOfPowerUps;

    public GameObject powerUp;


    public void Start()
    {
        //Task 1B
        accesleration = maxSpeed / accelerationTime;

        //Task 1C
        decelortion = maxSpeed / decelortionTime;

    }


    void Update()
    {

        PlayerMovement();
        EnemyRadar(radius, circlePoints);
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPowerups(radius, numOfPowerUps);
        }
        BlackHoleReset(blackRad);
        BlackHolePull(blackRad2);
    }

    public void PlayerMovement()
    {
        //Week 3 Task 1A
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //velocity = new Vector3 (horizontalInput, verticalInput);
        //transform.position = transform.position + velocity;

        //Week 3 Task 1B
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 totalInput = new Vector3(horizontalInput, verticalInput);

        if (totalInput.magnitude != 0)
        {
            velocity += totalInput * accesleration * Time.deltaTime;
        }
        else
        {
            velocity -= velocity * decelortion * Time.deltaTime;
        }

        if (velocity.magnitude < 0.001f)
        {
            velocity = Vector3.zero;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

        if (accesleration == maxSpeed)
        {
            Debug.Log("MAXREACHED");
        }

        //Week 3 Task 1C
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //velocity += new Vector3(horizontalInput, verticalInput) * decelortion * Time.deltaTime;
        //transform.position = transform.position + velocity;
    }

    //week 4 Task1 
    public void EnemyRadar(float radius, int circlePoints)
    {

        //colour of the line
        Color linecolor;

        if ((enemyTransform.position - transform.position).magnitude < radius)
        {
            linecolor = Color.red;
        }
        else
        {
            linecolor = Color.green;
        }

        float degre = 360f / circlePoints;
        float radians = degre * Mathf.Deg2Rad;

        for (int i = 0; i < circlePoints; i++)
        {
            Vector3 newPoint = new Vector3(Mathf.Sin( radians * i ), Mathf.Cos(radians * i )) * radius;
            Vector3 nextPoint = new Vector3(Mathf.Sin( radians * (i + 1)), Mathf.Cos(radians * (i + 1))) * radius;
            Debug.DrawLine( transform.position + newPoint, transform.position + nextPoint, linecolor);
        }

    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float degre = 360f / numberOfPowerups;
        float radians = degre * Mathf.Deg2Rad;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            Vector3 newPoint2 = new Vector3(Mathf.Sin(radians * i), Mathf.Cos(radians * i)) * radius;
            Instantiate(powerUp, newPoint2 + transform.position, Quaternion.identity);
        }

    }

    //Black hole Task 3 For Final Assignment
    public void BlackHoleReset(float blackRad)
    {
        // this statment tells the object that the player is in the back hole.
        if((blackHole.position - transform.position).magnitude < blackRad)
        {
            // this statment teleports the player back to the start when colliding with black hole. 
            transform.position = new Vector3(5, -5);
        }

        // these are all duplicates for the other blach holes
        if ((blackHole2.position - transform.position).magnitude < blackRad)
        {
            transform.position = new Vector3(5, -5);
        }

        if ((blackHole3.position - transform.position).magnitude < blackRad)
        { 
            transform.position = new Vector3(5, -5);
        }

        if ((blackHole4.position - transform.position).magnitude < blackRad)
        {
            transform.position = new Vector3(5, -5);
        }


    }

    public void BlackHolePull(float blackRad2)
    {
        //This if statemnet tells the object that the player is in the black holes radius
        if((blackHoleRadius.position - transform.position).magnitude < blackRad2)
        {
            // creating a local varible called direction using blackhole radius postion and subracting it from player posistion.
            Vector3 direction = (blackHoleRadius.position - transform.position).normalized;

            // speed at which the player moves towards the blackhole. 
            transform.position += direction * Time.deltaTime * 1f;
        }

        // these are all duplicates for the other blach holes
        if ((blackHoleRadius2.position - transform.position).magnitude < blackRad2)
        {
            Vector3 direction = (blackHoleRadius2.position - transform.position).normalized;

            transform.position += direction * Time.deltaTime * 1f;
        }

        if ((blackHoleRadius3.position - transform.position).magnitude < blackRad2)
        {
            Vector3 direction = (blackHoleRadius3.position - transform.position).normalized;

            transform.position += direction * Time.deltaTime * 1f;
        }

        if ((blackHoleRadius4.position - transform.position).magnitude < blackRad2)
        {
            Vector3 direction = (blackHoleRadius4.position - transform.position).normalized;

            transform.position += direction * Time.deltaTime * 1f;
        }
    }
}

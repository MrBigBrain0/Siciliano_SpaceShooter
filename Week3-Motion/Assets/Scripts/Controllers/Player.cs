using JetBrains.Annotations;
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
    Vector3 velocity;


    //Veriables for Task 1B
    public float maxSpeed ;
    public float accesleration;
    public float accelerationTime;

    //Variables for Task 1C
    public float decelortion;
    public float decelortionTime;

    //Variables for week 4 task 1

    //size of the radar
    public float radius = 0f;
    //number of points the radius has
    public int circlePoints = 6;


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
}

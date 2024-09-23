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

    }

}

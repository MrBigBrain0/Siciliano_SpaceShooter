using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class bomb : MonoBehaviour
{
    public Transform player;
    public Transform moon;
    public GameObject Bomb;
    public float radius;
    public float maxSpeed;
    public float acceleration;
    public float accelerationSpeed;

    public void Start()
    {
        acceleration = maxSpeed / accelerationSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        TrackPlayer(radius);
    }

    public void TrackPlayer(float radius)
    {

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * acceleration * Time.deltaTime;

    }
}

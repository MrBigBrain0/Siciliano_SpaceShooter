using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public Transform target;

    public float raduis = 2f;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(raduis, speed, target);
    }

    public void OrbitalMotion(float raduis, float speed, Transform target)
    {
        float degre = 360f;
        float radians = degre * Mathf.Deg2Rad;


    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public int numOfBomb;
    public int currentBomb;
    public float radius;
    public GameObject bomb;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bombspawner(numOfBomb, radius);
        }

    }

    public void bombspawner(int numOfBomb, float radius)
    {
        for (int i = 0; i < numOfBomb; i++)
        {
            Instantiate(bomb, new Vector3(18,7,0), Quaternion.identity);

        }
    }

}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float speed = 3f;
    public GameObject enemyPreFab;
    private void Update()
    {

        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 15), transform.position.y, -20 );

    }

}

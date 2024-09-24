using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RadioLines : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float raduis = 3f;
    public float delayInSeconds = 0.5f;
    private float ellapsedTime = 0;


    public List<float> angles;
    private int currrentAngle = 0;


    // Start is called before the first frame update
    private void Start()
    { 
        angles = new List<float>();

        for( int i = 0; i < 10; i++)
        {
            angles.Add(Random.value * 360);
        }
        
        transform.position += offset;   

    }

    // Update is called once per frame
    void Update()
    {
        ellapsedTime += Time.deltaTime;

        if (ellapsedTime > delayInSeconds)
        {
            currrentAngle = (currrentAngle + 1) % angles.Count;
            ellapsedTime = 0;   
        }
        
        float radians = Mathf.Deg2Rad * angles[currrentAngle] ;
        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint =  transform.position + new Vector3(xPos, yPos, 0f) * raduis;

        Debug.DrawLine(transform.position, endPoint, Color.magenta);
    }
}

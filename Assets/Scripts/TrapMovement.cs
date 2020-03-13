using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    public Transform[] point;
    public int startPoint;
    public int endPoint;
    public float speed;
    public float rotateangle;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = point[startPoint].position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateangle), Space.Self);
        transform.position = Vector2.MoveTowards(transform.position, point[endPoint].position, speed * Time.deltaTime);
        if (transform.position == point[endPoint].position)
        {
            endPoint++;
            if (endPoint == point.Length)
            {
                endPoint = 0;
            }
        }
    }
}

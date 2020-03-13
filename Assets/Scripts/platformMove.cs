using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    public Transform[] point;
    public int startPoint;
    public int endPoint;
    public float speed;
    public GameObject movingPlatW;
    public GameObject movingPlatB;
    private bool plat;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = point[startPoint].position;
        plat = true;
        movingPlatW.GetComponent<BoxCollider2D>().enabled = true;
        movingPlatB.GetComponent<BoxCollider2D>().enabled = false;
        //Debug.Log(movingPlatW.gameObject.GetComponent<BoxCollider2D>().enabled);
        //Debug.Log(movingPlatB.gameObject.GetComponent<BoxCollider2D>().enabled);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point[endPoint].position, speed * Time.deltaTime);

        if (transform.position == point[endPoint].position)
        {
            endPoint++;
            if (endPoint == point.Length)
            {
                endPoint = 0;
            }
        }
        if (((TagManager.whoIsIt == 1 && (Input.GetButtonDown("Player1SwitchKey") || Input.GetButtonDown("Player1Switch"))) || (TagManager.whoIsIt == 2 && (Input.GetButtonDown("Player2SwitchKey") || Input.GetButtonDown("Player2Switch"))) || (TagManager.whoIsIt == 3 && (Input.GetButtonDown("Player3SwitchKey") || Input.GetButtonDown("Player3Switch"))) || (TagManager.whoIsIt == 4 && (Input.GetButtonDown("Player4SwitchKey") || Input.GetButtonDown("Player4Switch")))))
        {
            //Debug.Log("it's in moving");
            plat = !plat;
            Debug.Log(plat);
            if (plat==true)
            {
                //Debug.Log("it's in black moving");
                movingPlatW.GetComponent<BoxCollider2D>().enabled = true;
                movingPlatB.GetComponent<BoxCollider2D>().enabled = false;
                /*Debug.Log(movingPlatW.gameObject.GetComponent<BoxCollider2D>().enabled);
                Debug.Log(movingPlatB.gameObject.GetComponent<BoxCollider2D>().enabled);
                Debug.Log(plat);*/

            }
            else
            {
                //Debug.Log("it's in white moving");
                movingPlatW.GetComponent<BoxCollider2D>().enabled = false;
                movingPlatB.GetComponent<BoxCollider2D>().enabled = true;
                /*Debug.Log(movingPlatW.gameObject.GetComponent<BoxCollider2D>().enabled);
                Debug.Log(movingPlatB.gameObject.GetComponent<BoxCollider2D>().enabled);
                Debug.Log(plat);*/
            }
        }
    }
}

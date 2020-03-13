using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableTrap : MonoBehaviour
{
    public GameObject whiteTrap;
    public GameObject blackTrap;
    //private bool check = true; 
    //private int x = 1;
    // Start is called before the first frame update
    void Start()
    {
        //whiteTrap.SetActive(true);
        //blackTrap.SetActive(false);
        whiteTrap.GetComponent<BoxCollider2D>().enabled = true;
        blackTrap.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
          //Debug.Log(whiteTrap.activeSelf);
          //Debug.Log(blackTrap.activeSelf);

         if (((TagManager.whoIsIt == 1 && (Input.GetButtonDown("Player1SwitchKey") || Input.GetButtonDown("Player1Switch"))) || (TagManager.whoIsIt == 2 && (Input.GetButtonDown("Player2SwitchKey") || Input.GetButtonDown("Player2Switch"))) || (TagManager.whoIsIt == 3 && (Input.GetButtonDown("Player3SwitchKey") || Input.GetButtonDown("Player3Switch"))) || (TagManager.whoIsIt == 4 && (Input.GetButtonDown("Player4SwitchKey") || Input.GetButtonDown("Player4Switch")))))
         {
             if (whiteTrap.activeSelf)
             {
                blackTrap.GetComponent<BoxCollider2D>().enabled = true;
                whiteTrap.GetComponent<BoxCollider2D>().enabled = false;
               // Debug.Log("it's in black");
             }
             else
             {
                whiteTrap.GetComponent<BoxCollider2D>().enabled = true;
                blackTrap.GetComponent<BoxCollider2D>().enabled = false;
                //Debug.Log("it's in white");
             }

         }
        /*  if (Input.GetButtonDown("Player1SwitchKey"))
          {
              Debug.Log("it's in white");
              whiteTrap.GetComponent<BoxCollider2D>().enabled = false;
          }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.gameObject.tag == "king")
        {
            collision.gameObject.gameObject.tag = "Player";
            collision.gameObject.transform.position = new Vector2(0, 0);

            TagManager.whoIsIt = Random.Range(1, 3);
            GameObject newKing = GameObject.Find("player" + TagManager.whoIsIt);
            newKing.tag = "king";
        }

    }
}

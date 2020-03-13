using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

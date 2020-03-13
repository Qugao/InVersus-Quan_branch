using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;


    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Bounds();
    }

    void Movement()
    {
        float horMove = Input.GetAxis("Player2Horizontal");

        if (horMove != 0)
        {
            rb.velocity = new Vector2(horMove * speed * Time.deltaTime, rb.velocity.y);
        }
        float faceDirection = Input.GetAxisRaw("Player2Horizontal");
        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(-faceDirection*4, 4, 4);
        }
        if (Input.GetButtonDown("Player2Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.gameObject.tag == "Player1" && !TagManager.player1It)
        //{
        //    Debug.Log("Player2 wins!");
        //    Destroy(collision.gameObject);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    void Bounds()
    {
        if (rb.position.x > 15)
        {
            rb.MovePosition(new Vector2(-14, rb.position.y));
        }
        if (rb.position.x < -15)
        {
            rb.MovePosition(new Vector2(14, rb.position.y));
        }
        if (rb.position.y > 8)
        {
            rb.MovePosition(new Vector2(rb.position.x, -5));
        }
        if (rb.position.y < -6)
        {
            rb.MovePosition(new Vector2(rb.position.x, 7));
        }
    }
}

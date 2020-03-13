using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float speedLimit = -18;
    public float jumpForce;
    public float direction;

    public bool dashing;
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;

    public Vector2 savedVelocity;

    // Start is called before the first frame update
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
        if (rb.velocity.y < speedLimit) rb.velocity = rb.velocity.normalized * -speedLimit;
        if (dashing)
        {
            dashMovement();
        }
        else
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                dashTimer = 0;
                dashState = DashState.Ready;
            }

            float horMove = Input.GetAxis("Player1Horizontal");
            if (horMove != 0)
            {
                rb.velocity = new Vector2(horMove * speed * Time.deltaTime, rb.velocity.y);
            }
            float faceDirection = Input.GetAxisRaw("Player1Horizontal");
            if (faceDirection != 0)
            {
                transform.localScale = new Vector3(4 * faceDirection, 4, 4);
            }
            if (Input.GetButtonDown("Player1Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
            if (Input.GetButtonDown("Player1Dash") && dashState == DashState.Ready)
            {
                dashing = true;
                dashMovement();
            }
        }

        if (rb.velocity.x < 0) direction = -1;
        else if (rb.velocity.x > 0) direction = 1;
        //Debug.Log(rb.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.gameObject.tag == "Player2" && TagManager.player1It)
        //{
        //    Debug.Log("Player1 wins!");
        //    Destroy(collision.gameObject);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    void Bounds()
    {
        if(rb.position.x > 15)
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

    void dashMovement()
    {
        switch (dashState)
        {
            case DashState.Ready:
                savedVelocity = rb.velocity;
                rb.velocity = new Vector2(30 * direction, rb.velocity.y);
                dashState = DashState.Dashing;
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    rb.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                    dashing = false;
                }
                break;
        }
    }
}

//public enum DashState
//{
//    Ready,
//    Dashing,
//    Cooldown
//}


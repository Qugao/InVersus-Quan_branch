using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmashBall : MonoBehaviour
{
    double velocity = 0;
    double angle = 0;
    private Rigidbody2D rb;
    private double i = 0;
    // Start is called before the first frame update

    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-14, 14), Random.Range(-7, 9), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Bounds();
        //perlin noise is used for random angle and velocity of smash ball
        double PerlinA = Mathf.PerlinNoise(this.transform.position.x, this.transform.position.y);
        double PerlinB = Mathf.PerlinNoise(this.transform.position.x, this.transform.position.y);
        rb.velocity = new Vector2((float)(5 * PerlinA * Mathf.Cos((float)angle)), (float)(5 * PerlinA * Mathf.Sin((float)angle)));
        if (Time.frameCount % 30 == 0)
        {
            angle += Remap((float)PerlinB,0,1,-15,15);
        }

    }
    float Remap(float value, float from1, float to1, float from2, float to2) => (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    void Bounds()
    {
        if (rb.position.x > 15)
        {
            this.transform.position = new Vector2(-15, this.transform.position.y);

        }
        if (rb.position.x < -15)
        {
            this.transform.position = new Vector2(15, this.transform.position.y);

        }
        if (rb.position.y > 9)
        {
            this.transform.position = new Vector2(this.transform.position.x, -7);

        }
        if (rb.position.y < -7)
        {
            this.transform.position = new Vector2(this.transform.position.x, 9);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //do something
        }
    }
}
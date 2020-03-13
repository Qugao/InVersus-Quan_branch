using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class GameController : MonoBehaviour
{
    public Text timerDisplay;
    public float timer = 300;
    public Text p1scoreDisplay;
    public Text p2scoreDisplay;
    public Text p3scoreDisplay;
    public Text p4scoreDisplay;
    private float p1score = 0;
    private float p2score = 0;
    private float p3score = 0;
    private float p4score = 0;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public Text respawnTime1;
    public Text respawnTime2;
    public Text respawnTime3;
    public Text respawnTime4;
    private float time1 = 5;
    private float time2 = 5;
    private float time3 = 5;
    private float time4 = 5;
    public AudioSource songstart;
    public AudioSource songloop;
    public GameObject pauseUI;
    public GameObject green;
    public GameObject purple;
    private Tilemap gTiles;
    private Tilemap pTiles;
    private TilemapCollider2D gCollision;
    private TilemapCollider2D pCollision;
    Color faded = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    Color opaque = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private bool flipped = false;
    //public GameObject blackBG;


    private bool inGame = true;

    // Start is called before the first frame update
    void Start()
    {
        if (songloop != null) {
            songloop.enabled = false;
        }
        PlaceScores();
        gTiles = green.GetComponent<Tilemap>();
        pTiles = purple.GetComponent<Tilemap>();
        gCollision = green.GetComponent<TilemapCollider2D>();
        pCollision = purple.GetComponent<TilemapCollider2D>();
        pTiles.color = faded;
        pCollision.enabled = false;

        // Disable players if player number is below 4
        if (GameObject.Find("passScore").GetComponent<StateManager>().getP3() == null) {
            GameObject.Find("player3").SetActive(false);
            GameObject.Find("P3 Score").SetActive(false);
            GameObject.Find("respawnTime3").SetActive(false);
        }

        if (GameObject.Find("passScore").GetComponent<StateManager>().getP4() == null)
        {
            GameObject.Find("player4").SetActive(false);
            GameObject.Find("P4 Score").SetActive(false);
            GameObject.Find("respawnTime4").SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (songstart != null && songloop != null)
		{
            if (!songstart.isPlaying && !songloop.enabled)
            {
                songloop.enabled = true;
                songloop.Play();
            }
        }
        if (p1.activeSelf == false)
        {
            time1 -= Time.deltaTime;
            respawnTime1.text = "" + time1;
        }
        if (p1.activeSelf == true)
        {
            respawnTime1.text = "Respawn Time";
            time1 = 5;
        }
        if (p2.activeSelf == false)
        {
            time2 -= Time.deltaTime;
            respawnTime2.text = "" + time2;
        }
        if (p2.activeSelf == true)
        {
            respawnTime2.text = "Respawn Time";
            time2 = 5;
        }
        if (p3.activeSelf == false)
        {
            time3 -= Time.deltaTime;
            respawnTime3.text = "" + time3;
        }
        if (p3.activeSelf == true)
        {
            respawnTime3.text = "Respawn Time";
            time3 = 5;
        }
        if (p4.activeSelf == false)
        {
            time4 -= Time.deltaTime;
            respawnTime4.text = "" + time4;
        }
        if (p4.activeSelf == true)
        {
            respawnTime4.text = "Respawn Time";
            time4 = 5;
        }
        if (inGame) //checks if the game is over
        {
            ManageScore();
            timer -= Time.deltaTime;
            timerDisplay.text = "" + timer;
            if (timer <= 0)
            {
                GameObject.Find("passScore").GetComponent<StateManager>().setS1(p1score);
                GameObject.Find("passScore").GetComponent<StateManager>().setS2(p2score);
                GameObject.Find("passScore").GetComponent<StateManager>().setS3(p3score);
                GameObject.Find("passScore").GetComponent<StateManager>().setS4(p4score);

                SceneManager.LoadScene("EndScreen");
                inGame = false;
            }
        }
        else //updates the scores
        {
            p1scoreDisplay = GameObject.Find("P1").GetComponent<Text>();
            p2scoreDisplay = GameObject.Find("P2").GetComponent<Text>();
            p3scoreDisplay = GameObject.Find("P3").GetComponent<Text>();
            p4scoreDisplay = GameObject.Find("P4").GetComponent<Text>();
            PlaceScores();
            Destroy(this.gameObject);
        }

        //CheckFlip(); //handles flip detection

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("CancelKey")) //this pauses the game
        {
            Pause();
        }
    }
    
    /*void CheckFlip() //for all your flipping needs
    {
        if (p1.tag == "king" && (Input.GetButtonDown("Player1SwitchKey") || Input.GetButtonDown("Player1Switch")))
            FlipWorld();
        if (p2.tag == "king" && (Input.GetButtonDown("Player2SwitchKey") || Input.GetButtonDown("Player2Switch")))
            FlipWorld();
        if (p3.tag == "king" && (Input.GetButtonDown("Player3SwitchKey") || Input.GetButtonDown("Player3Switch")))
            FlipWorld();
        if (p4.tag == "king" && (Input.GetButtonDown("Player4SwitchKey") || Input.GetButtonDown("Player4Switch")))
            FlipWorld();
    }

    void FlipWorld()
    {
        blackBG.SetActive(flipped);
        if (flipped == false)
        {
            gTiles.color = faded;
            gCollision.enabled = false;
            pTiles.color = opaque;
            pCollision.enabled = true;
            flipped = true;
        }
        else
        {
            gTiles.color = opaque;
            gCollision.enabled = true;
            pTiles.color = faded;
            pCollision.enabled = false;
            flipped = false;
        }
    }*/

    void ManageScore()
    {
        if (p1.tag == "king" || p1.tag == "invulnerable")
        {
            p1score += 0.1f;
            p1scoreDisplay.text = "P1: " + p1score;
        }
        if (p2.tag == "king" || p2.tag == "invulnerable")
        {
            p2score += 0.1f;
            p2scoreDisplay.text = "P2: " + p2score;
        }
        if (p3.tag == "king" || p3.tag == "invulnerable")
        {
            p3score += 0.1f;
            p3scoreDisplay.text = "P3: " + p3score;
        }
        if (p4.tag == "king" || p4.tag == "invulnerable")
        {
            p4score += 0.1f;
            p4scoreDisplay.text = "P4: " + p4score;
        }
    }

    void PlaceScores()
    {
        p1scoreDisplay.text = "P1: " + p1score;
        p2scoreDisplay.text = "P2: " + p2score;
        p3scoreDisplay.text = "P3: " + p3score;
        p4scoreDisplay.text = "P4: " + p4score;
    }

    public void Pause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
        Destroy(this.gameObject);
    }
}

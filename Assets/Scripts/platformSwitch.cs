using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class platformSwitch : MonoBehaviour
{
    public bool plat;
    public Tilemap white;
    public Tilemap black;
    public Color inviz;
    public Color viz;
    private float timeLeft;
    public AudioSource tick;
    private bool cooldown;
    //public GameObject White;
    //public GameObject Black;
    public GameObject inactiveBlack;
    public GameObject inactiveWhite;
    //public GameObject Bspike;
    //public GameObject Wspike;
    private Tilemap gTiles;
    private Tilemap pTiles;
    private TilemapCollider2D gCollision;
    private TilemapCollider2D pCollision;
    Color faded = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    Color opaque = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private bool flipped = false;
    public GameObject whiteBG;
    public GameObject blackBG;
    TilemapRenderer rendB;
    TilemapRenderer rendW;
    TilemapRenderer rendInB;
    TilemapRenderer rendInW;
    SpriteRenderer rendBBG;
    SpriteRenderer rendWBG;
    //SpriteRenderer rendBS;
    //SpriteRenderer rendWS;

    // Start is called before the first frame update
    void Start()
    {
        tick.volume = .8f;
        timeLeft = 5.0f;
        cooldown = true;
        plat = true;
        inviz = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        viz = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        gTiles = white.GetComponent<Tilemap>();
        pTiles = black.GetComponent<Tilemap>();
        gCollision = white.GetComponent<TilemapCollider2D>();
        pCollision = black.GetComponent<TilemapCollider2D>();
        pTiles.color = faded;
        pCollision.enabled = false;

        rendB = black.GetComponent<TilemapRenderer>();
        Color cB = rendB.material.color;
        cB.a = 0f;
        rendB.material.color = cB;

        rendW = white.GetComponent<TilemapRenderer>();
        Color cW = rendW.material.color;
        cW.a = 0f;
        rendW.material.color = cW;

        rendInB = inactiveBlack.GetComponent<TilemapRenderer>();
        Color cInB = rendInB.material.color;
        cInB.a = 0f;
        rendInB.material.color = cB;

        rendInW = inactiveWhite.GetComponent<TilemapRenderer>();
        Color cInW = rendInW.material.color;
        cInW.a = 0f;
        rendInW.material.color = cW;

        rendBBG = whiteBG.GetComponent<SpriteRenderer>();
        Color cBBG = rendBBG.material.color;
        cInW.a = 0f;
        rendInW.material.color = cW;

        rendWBG = blackBG.GetComponent<SpriteRenderer>();
        Color cWBG = rendWBG.material.color;
        cInW.a = 0f;
        rendInW.material.color = cW;

        /*rendBS = Bspike.GetComponent<SpriteRenderer>();
        Color cBS = rendBS.material.color;
        cBS.a = 0f;
        rendBS.material.color = cW;

        rendWS = Wspike.GetComponent<SpriteRenderer>();
        Color cWS = rendWS.material.color;
        cWS.a = 0f;
        rendWS.material.color = cW;*/

        for (int i = -10; i <= 9; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                white.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                black.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                black.SetColor(new Vector3Int(i, j, 0), inviz);
                white.SetColor(new Vector3Int(i, j, 0), viz);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft);
        if (timeLeft <= 2.5f && tick.isPlaying == false)
        {
            tick.Play();
        }
        if (timeLeft < 0)
        {
            cooldown = true;
        }

        if (/*((TagManager.whoIsIt == 1 && (Input.GetButtonDown("Player1SwitchKey") || Input.GetButtonDown("Player1Switch"))) || (TagManager.whoIsIt == 2 && (Input.GetButtonDown("Player2SwitchKey") || Input.GetButtonDown("Player2Switch"))) || (TagManager.whoIsIt == 3 && (Input.GetButtonDown("Player3SwitchKey") || Input.GetButtonDown("Player3Switch"))) || (TagManager.whoIsIt == 4 && (Input.GetButtonDown("Player4SwitchKey") || Input.GetButtonDown("Player4Switch")))) &&*/ cooldown)
        {

            //Debug.Log("switch active");
            plat = !plat;
            cooldown = false;
            timeLeft = 5.0f;
            if (plat)
            {
                //white.GetComponent<TilemapRenderer>().enabled = true;
                StartCoroutine("FadeInW");
                StartCoroutine("FadeOutB");
                StartCoroutine("FadeInWBG");
                StartCoroutine("FadeOutBBG");
                //black.GetComponent<TilemapRenderer>().enabled = false;
                //inactiveBlack.GetComponent<TilemapRenderer>().enabled = true;
            }
            else
            {
                //white.GetComponent<TilemapRenderer>().enabled = false;
                StartCoroutine("FadeInB");
                StartCoroutine("FadeOutW");
                StartCoroutine("FadeInBBG");
                StartCoroutine("FadeOutWBG");
                //black.GetComponent<TilemapRenderer>().enabled = true;
                //inactiveBlack.GetComponent<TilemapRenderer>().enabled = false;
            }

        }
    }

    IEnumerator FadeOutB()
    {
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c = rendB.material.color;
            c.a = f;
            rendB.material.color = c;
            Color c1 = rendInW.material.color;
            c1.a = f;
            rendInW.material.color = c1;
            /*Color c2 = rendBS.material.color;
            c2.a = f;
            rendBS.material.color = c2;*/
            yield return new WaitForSeconds(0.05f);

        }
    }

    IEnumerator FadeOutBBG()
    {
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c2 = rendBBG.material.color;
            c2.a = f;
            rendBBG.material.color = c2;
            yield return new WaitForSeconds(0.2f);

        }
    }

    IEnumerator FadeInB()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c = rendB.material.color;
            c.a = f;
            rendB.material.color = c;
            Color c1 = rendInW.material.color;
            c1.a = f;
            rendInW.material.color = c1;
            /*Color c2 = rendBS.material.color;
            c2.a = f;
            rendBS.material.color = c2;*/
            yield return new WaitForSeconds(0.05f);
        }
        inactiveWhite.GetComponent<TilemapRenderer>().enabled = true;
        FlipWorld();
        for (int i = -10; i <= 9; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                white.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                black.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                black.SetColor(new Vector3Int(i, j, 0), viz);
                white.SetColor(new Vector3Int(i, j, 0), inviz);
            }
        }
    }

    IEnumerator FadeInBBG()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c2 = rendBBG.material.color;
            c2.a = f;
            rendBBG.material.color = c2;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator FadeOutW()
    {
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c = rendW.material.color;
            c.a = f;
            rendW.material.color = c;
            Color c1 = rendInB.material.color;
            c1.a = f;
            rendInB.material.color = c1;
            /*Color c2 = rendWS.material.color;
            c2.a = f;
            rendWS.material.color = c2;*/
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOutWBG()
    {
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c2 = rendWBG.material.color;
            c2.a = f;
            rendWBG.material.color = c2;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator FadeInW()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c = rendW.material.color;
            c.a = f;
            rendW.material.color = c;
            Color c1 = rendInB.material.color;
            c1.a = f;
            rendInB.material.color = c1;
            /*Color c2 = rendWS.material.color;
            c2.a = f;
            rendWS.material.color = c2;*/
            yield return new WaitForSeconds(0.05f);
        }
        
        inactiveWhite.GetComponent<TilemapRenderer>().enabled = false;
        FlipWorld();
        for (int i = -10; i <= 9; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                white.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                black.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                black.SetColor(new Vector3Int(i, j, 0), inviz);
                white.SetColor(new Vector3Int(i, j, 0), viz);
            }
        }
    }  

    IEnumerator FadeInWBG()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c2 = rendWBG.material.color;
            c2.a = f;
            rendWBG.material.color = c2;

            yield return new WaitForSeconds(0.2f);
        }
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

    }
}

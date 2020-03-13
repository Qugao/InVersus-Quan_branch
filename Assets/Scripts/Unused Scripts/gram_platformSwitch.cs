using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gram_platformSwitch : MonoBehaviour
{
    public bool plat;
    public Tilemap green;
    public Tilemap purple;
    public Color inviz;
    public Color viz;
    private float timeLeft;
    private bool cooldown;
    public static float p1score = 0.0f;
    public static float p2score = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0.0f;
        cooldown = true;
        plat = true;
        inviz = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        viz = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        for (int i = -10; i <= 9; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                green.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                purple.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                purple.SetColor(new Vector3Int(i, j, 0), inviz);
                green.SetColor(new Vector3Int(i, j, 0), viz);
            }
        }
        purple.GetComponent<TilemapCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            cooldown = true;
        }

        //if (TagManager.player1It)
        //{
        //    p1score += Time.deltaTime;
        //}
        //else
        //{
        //    p2score += Time.deltaTime;
        //}

        if (((TagManager.whoIsIt == 1 && Input.GetKeyDown(KeyCode.F)) || (TagManager.whoIsIt == 2 && Input.GetKeyDown(KeyCode.RightControl))) && cooldown)
        {
            plat = !plat;
            cooldown = false;
            timeLeft = 2.0f;

            if (plat)
            {
                green.GetComponent<TilemapCollider2D>().enabled = true;
                for (int i = -10; i <= 9; i++)
                {
                    for (int j = -5; j <= 5; j++)
                    {
                        green.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                        purple.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                        purple.SetColor(new Vector3Int(i, j, 0), inviz);
                        green.SetColor(new Vector3Int(i, j, 0), viz);
                    }
                }
                purple.GetComponent<TilemapCollider2D>().enabled = false;
            }
            else
            {
                green.GetComponent<TilemapCollider2D>().enabled = false;
                for (int i = -10; i <= 9; i++)
                {
                    for (int j = -5; j <= 5; j++)
                    {
                        green.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                        purple.SetTileFlags(new Vector3Int(i, j, 0), TileFlags.None);
                        purple.SetColor(new Vector3Int(i, j, 0), viz);
                        green.SetColor(new Vector3Int(i, j, 0), inviz);
                    }
                }
                purple.GetComponent<TilemapCollider2D>().enabled = true;
            }
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

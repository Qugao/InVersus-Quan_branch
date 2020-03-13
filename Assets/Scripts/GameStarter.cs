using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    private bool loaded = false;
    public static int playerCount = 4;
    // Start is called before the first frame update
    void Start()
    {
        /*if (loaded)
        {
            GameObject.Find("player4").SetActive(false);
            Destroy(this.gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (loaded)
        {
            if (playerCount < 4)
            {
                Destroy(GameObject.FindWithTag("Player4"));
            }
            if (playerCount < 3)
            {
                Destroy(GameObject.FindWithTag("Player3"));
            }
           // Destroy(this.gameObject);
        }
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Selection");
        loaded = true;
        //GameObject.Find("TagManager").SetActive(false);
    }

    public void SetPlayercount(int k)
    {
        playerCount = k;
        GameObject.Find("passScore").GetComponent<StateManager>().setTotal(k);
    }

    public int getPlayercount() {
        return playerCount;
    }
}

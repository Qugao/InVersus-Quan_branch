using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class spikeSwitch : MonoBehaviour
{
    public bool plat;
    private float timeLeft;
    private bool cooldown;
    public GameObject Bspike;
    public GameObject Wspike;
    SpriteRenderer rendBS;
    SpriteRenderer rendWS;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 5.0f;
        cooldown = true;
        plat = true;


        rendBS = Bspike.GetComponent<SpriteRenderer>();
        Color cBS = rendBS.material.color;
        cBS.a = 0f;
        rendBS.material.color = cBS;

        rendWS = Wspike.GetComponent<SpriteRenderer>();
        Color cWS = rendWS.material.color;
        cWS.a = 0f;
        rendWS.material.color = cWS;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft);
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
                StartCoroutine("FadeInW");
                StartCoroutine("FadeOutB");
            }
            else
            {
                StartCoroutine("FadeInB");
                StartCoroutine("FadeOutW");
            }

        }
    }

    IEnumerator FadeOutB()
    {
        Bspike.GetComponent<BoxCollider2D>().enabled = false;
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c2 = rendBS.material.color;
            c2.a = f;
            rendBS.material.color = c2;
            yield return new WaitForSeconds(0.05f);

        }
    }

    IEnumerator FadeInB()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c2 = rendBS.material.color;
            c2.a = f;
            rendBS.material.color = c2;
            yield return new WaitForSeconds(0.05f);
        }
        Bspike.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator FadeOutW()
    {
        Wspike.GetComponent<BoxCollider2D>().enabled = false;
        for (float f = 1f; f >= -0.5f; f -= 0.05f)
        {
            Color c2 = rendWS.material.color;
            c2.a = f;
            rendWS.material.color = c2;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeInW()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c2 = rendWS.material.color;
            c2.a = f;
            rendWS.material.color = c2;
            yield return new WaitForSeconds(0.05f);
        }
        Wspike.GetComponent<BoxCollider2D>().enabled = true;
    }
}

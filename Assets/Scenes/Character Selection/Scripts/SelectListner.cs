using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectListner : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI t;
    public GameObject p3;
    public GameObject p4;
    public GameObject p3Join;
    public GameObject p4Join;

    private bool p3Check = false;
    private bool p4Check = false;
 
    void Start() {
        p3.SetActive(false);
        p4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Join game
        if (Input.GetButtonDown("Player3Start") && !p3Check)
        {
            int cur = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            p3.SetActive(true); // Enable selection
            p3Join.SetActive(false); // Disable tips
            p3Check = true;
            GameObject.Find("passScore").GetComponent<StateManager>().setTotal(++cur);
        }
        // Quit game
        else if (Input.GetButtonDown("Player3Start") && p3Check) {
            int cur = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            p3.SetActive(false);
            p3Join.SetActive(true);
            p3Check = false;
            GameObject.Find("passScore").GetComponent<StateManager>().setTotal(--cur);
        }

        if (Input.GetButtonDown("Player4Start") && !p4Check)
        {
            int cur = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            p4.SetActive(true);
            p4Join.SetActive(false);
            p4Check = true;
            GameObject.Find("passScore").GetComponent<StateManager>().setTotal(++cur);
        }
        else if (Input.GetButtonDown("Player4Start") && p4Check)
        {
            int cur = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            p4.SetActive(false);
            p4Join.SetActive(true);
            p4Check = false;
            GameObject.Find("passScore").GetComponent<StateManager>().setTotal(--cur);
        }


        // Input for developer testing
        if (Input.GetKeyDown(KeyCode.Alpha3) && !p3Check)
        {
            int cur = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            p3.SetActive(true);
            p3Join.SetActive(false);
            p3Check = true;
            GameObject.Find("passScore").GetComponent<StateManager>().setTotal(++cur);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !p4Check)
        {
            int cur = GameObject.Find("passScore").GetComponent<StateManager>().getTotal();
            p4.SetActive(true);
            p4Join.SetActive(false);
            p4Check = true;
            GameObject.Find("passScore").GetComponent<StateManager>().setTotal(++cur);
        }
    }

}

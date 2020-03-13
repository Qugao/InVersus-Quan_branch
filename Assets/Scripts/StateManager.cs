using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    static float s1 = 0;
    static float s2 = 0;
    static float s3 = 0;
    static float s4 = 0;

    static int totalPlayer = 2;

    static Character p1;
    static Character p2;
    static Character p3;
    static Character p4;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // s += 1;
      //  Debug.Log(s); 
    }

    public void toLvlSelect()
    {
        SceneManager.LoadScene("LvlSelect");
    }

    public void toGame()
    {
        SceneManager.LoadScene("Selection");
    }

    public void toMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void toSetting()
    {
        SceneManager.LoadScene("Setting");
    }


    public void setTotal(int target) {
        totalPlayer = target;
    }

    public int getTotal() {
        return totalPlayer;
    }

    // Setter and getter for players score
    public void setS1(float target) {
        s1 = target;
    }

    public float getS1() {
        return s1;
    }

    public void setS2(float target)
    {
        s2 = target;
    }

    public float getS2()
    {
        return s2;
    }

    public void setS3(float target)
    {
        s3 = target;
    }

    public float getS3()
    {
        return s3;
    }

    public void setS4(float target)
    {
        s4 = target;
    }

    public float getS4()
    {
        return s4;
    }

    //-------

    public void setP1(Character target)
    {
        p1 = target;
    }

    public Character getP1()
    {
        return p1;
    }

    public void setP2(Character target)
    {
        p2 = target;
    }

    public Character getP2()
    {
        return p2;
    }

    public void setP3(Character target)
    {
        p3 = target;
    }

    public Character getP3()
    {
        return p3;
    }

    public void setP4(Character target)
    {
        p4 = target;
    }

    public Character getP4()
    {
        return p4;
    }
}

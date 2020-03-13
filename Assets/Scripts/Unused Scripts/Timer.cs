
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TotalTime;//倒计时总时间
    public float RateTime;//倒计时速率
    public float TargetTime;//倒计时的目标时间
    //private float CurrentTime;//当前倒计时剩余时间
    static public float CurrentTime;
    private Text ShowTime;
    public bool IsRepeat = false;//是否循环倒计时

    // Use this for initialization
    void Start()
    {
        CurrentTime = TotalTime;
        ShowTime = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        CurrentTime -= RateTime * Time.deltaTime;
        if (CurrentTime < TargetTime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (IsRepeat)//循环倒计时
            {
                CurrentTime = TotalTime;
            }
        }
        else
            ShowTime.text = CurrentTime.ToString("F2");//显示倒计时时间

    }
}
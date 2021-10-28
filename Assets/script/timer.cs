using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timeText;
    public Text GoalTime;
    private float time;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("f2");
        string hour = (((int)t / 60)/60).ToString("00");

        timeText.text = "Time " + hour + ":" + minutes + ":" + seconds;
        GoalTime.text = "Time " + hour + ":" + minutes + ":" + seconds;
    }
}

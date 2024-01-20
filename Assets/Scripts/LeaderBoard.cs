using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update

    public Text stpTime1;
    public Text stpTime2;
    public Text stpTime3;
    public Text coTime1;
    public Text coTime2;
    public Text coTime3;
    public float placedTime;
    public float placedTime2;
    public List<float> times = new List<float>();
    public List<float> times2 = new List<float>();
    public List<float> trueTimes = new List<float>();
    public List<float> trueTimes2 = new List<float>();



    void Start()
    {

        times = GlobalControl.Instance.times;
        times2 = GlobalControl.Instance.times2;

        
        placedTime = GlobalControl.Instance.timerTime;
        placedTime2 = GlobalControl.Instance.timerTime2;

        if (!times.Contains(placedTime) || !times.Contains(placedTime2))
        {
            times.Add(placedTime);
            times2.Add(placedTime2);
        }

        times.Sort();
        times.Reverse();
        times2.Sort();
        times2.Reverse();

        times.Add(0);
        times.Add(0);
        times.Add(0);
        times2.Add(0);
        times2.Add(0);
        times2.Add(0);

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(times[0]);
        TimeSpan time2 = TimeSpan.FromSeconds(times[1]);
        TimeSpan time3 = TimeSpan.FromSeconds(times[2]);
        stpTime1.text = time.ToString(@"mm\:ss");
        stpTime2.text = time2.ToString(@"mm\:ss");
        stpTime3.text = time3.ToString(@"mm\:ss");

        TimeSpan twotime = TimeSpan.FromSeconds(times2[0]);
        TimeSpan twotime2 = TimeSpan.FromSeconds(times2[1]);
        TimeSpan twotime3 = TimeSpan.FromSeconds(times2[2]);
        coTime1.text = twotime.ToString(@"mm\:ss");
        coTime2.text = twotime2.ToString(@"mm\:ss");
        coTime3.text = twotime3.ToString(@"mm\:ss");
    }
}

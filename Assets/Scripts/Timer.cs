using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float currentTime;
    public TextMesh currentTimeText;
    public TextMesh currentTimeText2;
    public float currentTime2;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = GlobalControl.Instance.timerTime;
        currentTime2 = GlobalControl.Instance.timerTime;
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            currentTime = 0;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 3"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 4"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 5"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 6"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 7"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 8"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 9"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 10"))
        {
            currentTime = GlobalControl.Instance.timerTime;
        }

        if (SceneManager.GetActiveScene().name.Equals("2Player Level 1"))
        {
            currentTime2 = 0;
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 2"))
        {
            currentTime2 = GlobalControl.Instance.timerTime2;
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 3"))
        {
            currentTime2 = GlobalControl.Instance.timerTime2;
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 4"))
        {
            currentTime2 = GlobalControl.Instance.timerTime2;
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 5"))
        {
            currentTime2 = GlobalControl.Instance.timerTime2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneManager.GetActiveScene().name[0].Equals('2'))
        {
            currentTime = currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            GlobalControl.Instance.timerTime = currentTime;
            currentTimeText.text = time.ToString(@"mm\:ss");
        } else
        {
            currentTime2 = currentTime2 + Time.deltaTime;
            TimeSpan time2 = TimeSpan.FromSeconds(currentTime2);
            GlobalControl.Instance.timerTime2 = currentTime2;
            currentTimeText2.text = time2.ToString(@"mm\:ss");
        }

    }
}

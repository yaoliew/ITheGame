using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelControl : MonoBehaviour
{

    public GameObject[] letters;
    public GameObject winText;
    public GameObject hintText;
    public GameObject hintText2;
    public GameObject hintText3;
    public int numberOfHints = 0;

    private bool victoryPlayed = false;

    private void Start()
    {
        letters = GameObject.FindGameObjectsWithTag("AttachmentLetter");
    }


    void Update()
    {

        int numOfLetters = 0;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main_Menu");
        }

        if (Input.GetKey("r"))
        {
            Restart();
        }

        if (Input.GetKeyDown("h"))
        {
            if(numberOfHints == 0)
            {
                hintText.gameObject.SetActive(true);
            }
            else if(numberOfHints == 1)
            {
                hintText2.gameObject.SetActive(true);
            }
            else if (numberOfHints == 2)
            {
                hintText3.gameObject.SetActive(true);
            }

            numberOfHints++;
        }

        foreach (var letter in letters)
        {
            if ((Mathf.Abs(letter.transform.position.x) >= 10) && (Mathf.Abs(letter.transform.position.y) >= 10))
            {
                numOfLetters++;
            }
        }

        if(numOfLetters == letters.Length)
        {
            winText.gameObject.SetActive(true);
            if (!victoryPlayed) {
                SoundManagerScript.PlaySound("victory");
                victoryPlayed = true;
            }
            if (Input.anyKeyDown)
            {
                nextLevel();
                numOfLetters = 0;
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void nextLevel()
    {
        if (SceneManager.GetActiveScene().name.Equals("Level 1"))
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 2"))
        {
            SceneManager.LoadScene("Level 3");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 3"))
        {
            SceneManager.LoadScene("Level 4");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 4"))
        {
            SceneManager.LoadScene("Level 5");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 5"))
        {
            SceneManager.LoadScene("Level 6");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 6"))
        {
            SceneManager.LoadScene("Level 7");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 7"))
        {
            SceneManager.LoadScene("Level 8");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 8"))
        {
            SceneManager.LoadScene("Level 9");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 9"))
        {
            SceneManager.LoadScene("Level 10");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level 10"))
        {
            SceneManager.LoadScene("Main_Menu");
        }

        if (SceneManager.GetActiveScene().name.Equals("2Player Level 1"))
        {
            SceneManager.LoadScene("2Player Level 2");
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 2"))
        {
            SceneManager.LoadScene("2Player Level 3");
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 3"))
        {
            SceneManager.LoadScene("2Player Level 4");
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 4"))
        {
            SceneManager.LoadScene("2Player Level 5");
        }
        else if (SceneManager.GetActiveScene().name.Equals("2Player Level 5"))
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}

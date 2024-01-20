using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Update()
    {
        /* if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        } */
    }


    public void levelSelect()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level_Select");
    }

    public void quitGame()
    {
        SoundManagerScript.PlaySound("click");
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void levelSelect2Player()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level_Select_2Player");
    }

    public void mainMenu()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Main_Menu");
    }

    public void Level1()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 3");
    }

    public void Level4()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 4");
    }

    public void Level5()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 5");
    }

    public void Level6()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 6");
    }

    public void Level7()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 7");
    }

    public void Level8()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 8");
    }

    public void Level9()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 9");
    }

    public void Level10()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("Level 10");
    }



    public void TwoPlayerLevel1()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("2Player Level 1");
    }

    public void TwoPlayerLevel2()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("2Player Level 2");
    }

    public void TwoPlayerLevel3()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("2Player Level 3");
    }

    public void TwoPlayerLevel4()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("2Player Level 4");
    }

    public void TwoPlayerLevel5()
    {
        SoundManagerScript.PlaySound("click");
        SceneManager.LoadScene("2Player Level 5");
    }

    public void TwoPlayerLevel6()
    {
        SceneManager.LoadScene("2Player Level 6");
    }

    public void TwoPlayerLevel7()
    {
        SceneManager.LoadScene("2Player Level 7");
    }

    public void TwoPlayerLevel8()
    {
        SceneManager.LoadScene("2Player Level 8");
    }

    public void TwoPlayerLevel9()
    {
        SceneManager.LoadScene("2Player Level 9");
    }

    public void TwoPlayerLevel10()
    {
        SceneManager.LoadScene("2Player Level 10");
    }
}

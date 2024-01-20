using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject title;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveOn());
    }

    IEnumerator moveOn()
    {

        StartCoroutine(fadeIn(title.gameObject.GetComponent<SpriteRenderer>(), 1f));


        yield return new WaitForSeconds(7f);


        SceneManager.LoadScene("Main_Menu");

        yield return null;

    }

    public void loadMenu() 
    {
        SceneManager.LoadScene("Main_Menu");
    }


    IEnumerator fadeIn(SpriteRenderer MyRenderer, float duration)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0, 1, counter / duration);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame

            yield return null;
        }
    }

}

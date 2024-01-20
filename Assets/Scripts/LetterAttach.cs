using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAttach : MonoBehaviour
{

    public GameObject[] letters;
    public GameObject mainLetter;
    public GameObject player;



    void Start()
    {
        letters = GameObject.FindGameObjectsWithTag("AttachmentLetter");
    }

    //Detects collision
    public void OnTriggerStay2D(Collider2D other)
    {
        foreach (var letter in letters)
        {

            // only recognize distance on verticals and horizontals, prevents diagonal letters from attaching
            float disX = Mathf.Abs(mainLetter.transform.position.x - letter.transform.position.x);
            float disY = Mathf.Abs(mainLetter.transform.position.y - letter.transform.position.y);

            float disX2 = Mathf.Abs(player.transform.position.x - mainLetter.transform.position.x);
            float disY2 = Mathf.Abs(player.transform.position.y - mainLetter.transform.position.y);

            if ((disX == 0 && disY <= 1f) || (disX <= 1f && disY == 0))
            {
                letter.transform.parent = mainLetter.transform;


                if (letter.name[0].Equals('R'))
                {
                    letter.transform.parent = null;
                    if (!(letter.transform.position.x == 15) && !(letter.transform.position.y == 15))
                    {
                        Debug.Log("what up");
                        letter.transform.parent = player.transform;
                        if(disY2 >= 0.1 && disX2 >= 0.1)
                        {
                            letter.transform.parent = null;
                        }
                    }
                    
                }
            }
        }
    }
     
    void Update()
    {
        //makes sure distance is only 1
        foreach (var letter in letters)
        {
            float disX2 = (mainLetter.transform.position.x - letter.transform.position.x);
            float disY2 = (mainLetter.transform.position.y - letter.transform.position.y);
            if (disX2 == 0)
            {
                if (disY2 <= 1 && disY2 > 0)
                {
                    letter.transform.position = mainLetter.transform.position + new Vector3(0, -1, 0);
                }
                else if (disY2 >= -1 && disY2 < 0)
                {
                    letter.transform.position = mainLetter.transform.position + new Vector3(0, 1, 0);
                }
            }
            else if (disY2 == 0)
            {
                if (disX2 <= 1 && disX2 > 0)
                {
                    letter.transform.position = mainLetter.transform.position + new Vector3(-1, 0, 0);
                }
                else if (disX2 >= -1 && disX2 < 0)
                {
                    letter.transform.position = mainLetter.transform.position + new Vector3(1, 0, 0);
                }

            }
        }
    }
}

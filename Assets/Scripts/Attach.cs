using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{

    public GameObject[] letters;
    public GameObject[] letters2;
    public GameObject player;
    public bool crateCheck = false;
    private string wordTop = "";
    private string wordBottom = "";
    private string wordRight = "";
    [SerializeField] string wordLeft = "";
    private string wordTop2 = "";
    private string wordBottom2 = "";
    private string wordRight2 = "";
    private string wordLeft2 = "";
    private string wordTop3 = "";
    private string wordBottom3 = "";
    private string wordRight3 = "";
    private string wordLeft3 = "";
    private string wordTop4 = "";
    private string wordBottom4 = "";
    private string wordRight4 = "";
    private string wordLeft4 = "";
    private string stoneWordLeft = "";
    [SerializeField] string stoneWordRight = "";
    [SerializeField] string stoneWordTop = "";
    private string stoneWordBottom = "";
    private string stoneWordLeft2 = "";
    [SerializeField] string stoneWordRight2 = "";
    [SerializeField] string stoneWordTop2 = "";
    private string stoneWordBottom2 = "";
    private string stoneWordLeft3 = "";
    private string stoneWordRight3 = "";
    private string stoneWordTop3 = "";
    [SerializeField] string stoneWordBottom3 = "";
    private string stoneWordLeft4 = "";
    private string stoneWordRight4 = "";
    private string stoneWordTop4 = "";
    private string stoneWordBottom4 = "";
    private List<GameObject> letters3 = new List<GameObject>();
    [SerializeField] TextAsset allWords;
    public string wordHorizontal;
    public string wordVertical;
    public string stoneWordHorizontal;
    public string stoneWordVertical;
    public int wordHorizontalLength;
    public int wordVerticalLength;
    [SerializeField] bool stoneWordMade = false;
    [SerializeField] bool isWordInList;
    [SerializeField] int numberOfWordsMade = 1;
    public bool horizontalWordMade;
    public bool verticalWordMade;


    void Start()
    {
        //Adds all the letters on the board into a list
        letters = GameObject.FindGameObjectsWithTag("AttachmentLetter");
        letters2 = GameObject.FindGameObjectsWithTag("AttachmentLetter");

        //makes all the letters act as walls before being atatched
        foreach(var letter in letters)
        {
            letter.layer = LayerMask.NameToLayer("WhatStopsMovement");
        }
    }
    
    //Detects collision
    public void OnTriggerStay2D(Collider2D other) {
        foreach (var letter in letters)
        {

            // only recognize distance on verticals and horizontals, prevents diagonal letters from attaching
            float disX = Mathf.Abs(player.transform.position.x - letter.transform.position.x);
            float disY = Mathf.Abs(player.transform.position.y - letter.transform.position.y);


            if ((disX == 0 && disY <= 1f) || (disX <= 1f && disY == 0))
            {
                
                if (!letter.name[0].Equals('F'))
                {
                    //makes sure fireletters can only be attached to other letters
                    letter.transform.parent = player.transform;
                }
                if (!letter.name[0].Equals('R'))
                {
                    //stops rock letters from being attached if the player didn't make a word
                    letter.layer = LayerMask.NameToLayer("Default");
                    if (letter.name[0].Equals('F'))
                    {
                        letter.layer = LayerMask.NameToLayer("WhatStopsMovement");
                    }
                }
                if (letter.name[0].Equals('R'))
                {
                    //reverts rock letters back into a wall
                    letter.layer = LayerMask.NameToLayer("WhatStopsMovement");
                    checkWord();
                    wordInList();
                }

            }
            
        }
    }

    void Update()
    {

        //makes sure distance is only 1
        foreach (var letter in letters)
        {
            float disX2 = (player.transform.position.x - letter.transform.position.x);
            float disY2 = (player.transform.position.y - letter.transform.position.y);

            if (disX2 == 0)
            {
                if (disY2 <= 1 && disY2 > 0)
                {
                    letter.transform.position = player.transform.position + new Vector3(0, -1, 0);
                }
                else if (disY2 >= -1 && disY2 < 0)
                {
                    letter.transform.position = player.transform.position + new Vector3(0, 1, 0);
                }
            }
            else if (disY2 == 0)
            {
                if (disX2 <= 1 && disX2 > 0)
                {
                    letter.transform.position = player.transform.position + new Vector3(-1, 0, 0);
                }
                else if (disX2 >= -1 && disX2 < 0)
                {
                    letter.transform.position = player.transform.position + new Vector3(1, 0, 0);
                }

            }

            if (letter.transform.IsChildOf(player.transform))
            {
                //makes the letters moveable after being atatched
                letter.layer = LayerMask.NameToLayer("Default");
            }

            if (disX2 == 0 || disY2 == 0)
            {
                if (letter.transform.IsChildOf(player.transform))
                {
                    if (letter.name[0].Equals('R'))
                    {
                        //reverts the saved stone word back to null if word is not made
                        checkWord();
                        wordInList();
                        letter.layer = LayerMask.NameToLayer("WhatStopsMovement");
                        if (isWordInList == false)
                        {
                            stoneWordHorizontal = "";
                            stoneWordVertical = "";
                            if (numberOfWordsMade == 1)
                            {
                                stoneWordRight = "";
                                stoneWordLeft = "";
                                stoneWordTop = "";
                                stoneWordBottom = "";
                            }
                            else if (numberOfWordsMade == 2)
                            {
                                stoneWordRight2 = "";
                                stoneWordLeft2 = "";
                                stoneWordTop2 = "";
                                stoneWordBottom2 = "";
                            }
                            else if (numberOfWordsMade == 3)
                            {

                                stoneWordRight3 = "";
                                stoneWordLeft3 = "";
                                stoneWordTop3 = "";
                                stoneWordBottom3 = "";
                            }
                            else if (numberOfWordsMade == 4)
                            {
                                stoneWordRight4 = "";
                                stoneWordLeft4 = "";
                                stoneWordTop4 = "";
                                stoneWordBottom4 = "";
                            }
                            letter.transform.parent = null;
                        }
                    }
                }
            }
        }

        //checks for the word
        checkWord();
        wordInList();
        wordRemove();
    }

    public void wordRemove()
    {
        //checks if a word is made
        if (isWordInList == true)
        {
            //deletes all crates that are the same length
            crateCheck = true;


            //fades away the letters
            foreach (var letter in letters)
            {
                float disX = (player.transform.position.x - letter.transform.position.x);
                float disY = (player.transform.position.y - letter.transform.position.y);

                if (letter.transform.IsChildOf(player.transform))
                {
                    if (disX <= 0 && (verticalWordMade))
                    {
                        Debug.Log(letter.name);
                        StartCoroutine(fadeOut(letter.gameObject.GetComponent<SpriteRenderer>(), 0.1f, letter));
                    }
                    if (disY <= 0 && (horizontalWordMade))
                    {
                        Debug.Log("yo waht up");
                        StartCoroutine(fadeOut(letter.gameObject.GetComponent<SpriteRenderer>(), 0.1f, letter));
                    }
                    SoundManagerScript.PlaySound("letterDestroy");
                }
            }

            //dectes the stone word length
            if (stoneWordMade == false)
            {
                wordHorizontalLength = wordHorizontal.Length;
                wordVerticalLength = wordVertical.Length;
            } else
            {
                wordHorizontalLength = stoneWordHorizontal.Length;
                wordVerticalLength = stoneWordVertical.Length;
            }

            //reverts all the stored words back to nothing
            wordHorizontal = "";
            wordVertical = "";
            stoneWordHorizontal = "";
            stoneWordVertical = "";
            stoneWordRight = "";
            stoneWordRight2 = "";
            stoneWordRight3 = "";
            stoneWordRight4 = "";
            stoneWordLeft = "";
            stoneWordLeft2 = "";
            stoneWordLeft3 = "";
            stoneWordLeft4 = "";
            stoneWordTop = "";
            stoneWordTop2 = "";
            stoneWordTop3 = "";
            stoneWordTop4 = "";
            stoneWordBottom = "";
            stoneWordBottom2 = "";
            stoneWordBottom3 = "";
            stoneWordBottom4 = "";

            //adds to the words made
            isWordInList = false;
            stoneWordMade = false;
            numberOfWordsMade++;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //check the word
        checkWord();
    }
    public void checkWord()
    {
        //turns the player letter into a character
        string playerLetter = spriteToLetter(player.gameObject.GetComponent<SpriteRenderer>().sprite.name);

        //adds the attached letters into a string
        foreach (var letter in letters2)
        {
            if (letter.transform.IsChildOf(player.transform))
            {
                //makes sure its only vertical or horizontal
                float disX = Mathf.Abs(player.transform.position.x - letter.transform.position.x);
                float disY = Mathf.Abs(player.transform.position.y - letter.transform.position.y);

                
                //vertical words
                if (disX == 0)
                {
                    //gets the character of the letter
                    string startLetter = letter.gameObject.GetComponent<SpriteRenderer>().sprite.name;
                    if (letter.transform.position.y >= player.transform.position.y + 1)
                    {
                        //does't add if it stone word wasn't a word
                        if (letter.name[0].Equals('R'))
                        {
                            if (stoneWordMade == false)
                            {
                                letters3.Remove(letter);
                            }
                        }
                        //adds the letter to the word string
                        if (!letters3.Contains(letter)) {
                            if (!letter.name[0].Equals('R'))
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    wordTop = spriteToLetter(startLetter) + wordTop;
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    wordTop2 = spriteToLetter(startLetter) + wordTop2;
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    wordTop3 = spriteToLetter(startLetter) + wordTop3;
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    wordTop4 = spriteToLetter(startLetter) + wordTop4;
                                }
                            }
                            else
                            {
                                //adds the stone letter to the word string
                                if (numberOfWordsMade == 1)
                                {
                                    stoneWordTop = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    stoneWordTop2 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    stoneWordTop3 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    stoneWordTop4 = spriteToLetter(startLetter);
                                }
                            }
                            letters3.Add(letter);
                        }
                    }
                    //does the same things as the above but for the bottom
                    if (letter.transform.position.y <= player.transform.position.y - 1)
                    {
                        if (letter.name[0].Equals('R'))
                        {
                            if (stoneWordMade == false)
                            {
                                letters3.Remove(letter);
                            }
                        }
                        if (!letters3.Contains(letter))
                        {
                            if (!letter.name[0].Equals('R'))
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    wordBottom = wordBottom + spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    wordBottom2 = wordBottom2 + spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    wordBottom3 = wordBottom3 + spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    wordBottom4 = wordBottom4 + spriteToLetter(startLetter);
                                }
                            }
                            else
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    stoneWordBottom = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    stoneWordBottom2 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    stoneWordBottom3 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    stoneWordBottom4 = spriteToLetter(startLetter);
                                }
                            }
                            letters3.Add(letter);
                        }
                    }
                }

                //horizontal words
                if (disY == 0)
                {
                    //does the same things as the above but for horizontal
                    string startLetter = letter.gameObject.GetComponent<SpriteRenderer>().sprite.name;
                    if (letter.transform.position.x >= player.transform.position.x + 1)
                    {
                        if (letter.name[0].Equals('R'))
                        {
                            if (stoneWordMade == false)
                            {
                                letters3.Remove(letter);
                            }
                        }
                        if (!letters3.Contains(letter))
                        {
                            if (!letter.name[0].Equals('R'))
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    wordRight = wordRight + spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    wordRight2 = wordRight2 + spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    wordRight3 = wordRight3 + spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    wordRight4 = wordRight4 + spriteToLetter(startLetter);
                                }
                            }
                            else
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    stoneWordRight = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    stoneWordRight2 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    stoneWordRight3 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    stoneWordRight4 = spriteToLetter(startLetter);
                                }
                            }
                            letters3.Add(letter);
                        }
                    }
                    if (letter.transform.position.x <= player.transform.position.x - 1)
                    {
                        if (letter.name[0].Equals('R'))
                        {
                            if (stoneWordMade == false)
                            {
                                letters3.Remove(letter);
                            }
                        }
                        if (!letters3.Contains(letter))
                        {
                            if (!letter.name[0].Equals('R'))
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    wordLeft = spriteToLetter(startLetter) + wordLeft;
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    wordLeft2 = spriteToLetter(startLetter) + wordLeft2;
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    wordLeft3 = spriteToLetter(startLetter) + wordLeft3;
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    wordLeft4 = spriteToLetter(startLetter) + wordLeft4;
                                }
                                
                            }
                            else
                            {
                                if (numberOfWordsMade == 1)
                                {
                                    stoneWordLeft = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 2)
                                {
                                    stoneWordLeft2 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 3)
                                {
                                    stoneWordLeft3 = spriteToLetter(startLetter);
                                }
                                else if (numberOfWordsMade == 4)
                                {
                                    stoneWordLeft4 = spriteToLetter(startLetter);
                                }
                            }
                            letters3.Add(letter);
                        }
                    }
                }

                //adds the word string to a bigger string of the entire word
                if (numberOfWordsMade == 1)
                {
                    wordVertical = wordTop + playerLetter + wordBottom;
                    wordHorizontal = wordLeft + playerLetter + wordRight;
                    stoneWordVertical = stoneWordTop + wordVertical + stoneWordBottom;
                    stoneWordHorizontal = stoneWordLeft + wordHorizontal + stoneWordRight;
                }
                else if (numberOfWordsMade == 2)
                {
                    wordVertical = wordTop2 + playerLetter + wordBottom2;
                    wordHorizontal = wordLeft2 + playerLetter + wordRight2;
                    stoneWordVertical = stoneWordTop2 + wordVertical + stoneWordBottom2;
                    stoneWordHorizontal = stoneWordLeft2 + wordHorizontal + stoneWordRight2;
                }
                else if (numberOfWordsMade == 3)
                {
                    wordVertical = wordTop3 + playerLetter + wordBottom3;
                    wordHorizontal = wordLeft3 + playerLetter + wordRight3;
                    stoneWordVertical = stoneWordTop3 + wordVertical + stoneWordBottom3;
                    stoneWordHorizontal = stoneWordLeft3 + wordHorizontal + stoneWordRight3;
                }
                else if (numberOfWordsMade == 4)
                {
                    wordVertical = wordTop4 + playerLetter + wordBottom4;
                    wordHorizontal = wordLeft4 + playerLetter + wordRight4;
                    stoneWordVertical = stoneWordTop4 + wordVertical + stoneWordBottom4;
                    stoneWordHorizontal = stoneWordLeft4 + wordHorizontal + stoneWordRight4;
                }
            }
        }
    }

    //converts the sprite of the letter into a character
    public string spriteToLetter(string spriteName)
    {
        if(string.Equals(spriteName, "A_PLetter_IGame") || string.Equals(spriteName, "A_SLetter_IGame") || string.Equals(spriteName, "A_FLetter_IGame"))
        {
            return "a";
        }
        else if(string.Equals(spriteName, "B_PLetter_IGame") || string.Equals(spriteName, "B_SLetter_IGame") || string.Equals(spriteName, "B_FLetter_IGame"))
        {
            return "b";
        }
        else if (string.Equals(spriteName, "C_PLetter_IGame") || string.Equals(spriteName, "C_SLetter_IGame") || string.Equals(spriteName, "C_FLetter_IGame"))
        {
            return "c";
        }
        else if (string.Equals(spriteName, "D_PLetter_IGame") || string.Equals(spriteName, "D_SLetter_IGame") || string.Equals(spriteName, "D_FLetter_IGame"))
        {
            return "d";
        }
        else if (string.Equals(spriteName, "E_PLetter_IGame") || string.Equals(spriteName, "E_SLetter_IGame") || string.Equals(spriteName, "E_FLetter_IGame"))
        {
            return "e";
        }
        else if (string.Equals(spriteName, "F_PLetter_IGame") || string.Equals(spriteName, "F_SLetter_IGame") || string.Equals(spriteName, "F_FLetter_IGame"))
        {
            return "f";
        }
        else if (string.Equals(spriteName, "G_PLetter_IGame") || string.Equals(spriteName, "G_SLetter_IGame") || string.Equals(spriteName, "G_FLetter_IGame"))
        {
            return "g";
        }
        else if (string.Equals(spriteName, "H_PLetter_IGame") || string.Equals(spriteName, "H_SLetter_IGame") || string.Equals(spriteName, "H_FLetter_IGame"))
        {
            return "h";
        }
        else if (string.Equals(spriteName, "J_PLetter_IGame") || string.Equals(spriteName, "J_SLetter_IGame") || string.Equals(spriteName, "J_FLetter_IGame"))
        {
            return "j";
        }
        else if (string.Equals(spriteName, "K_PLetter_IGame") || string.Equals(spriteName, "K_SLetter_IGame") || string.Equals(spriteName, "K_FLetter_IGame"))
        {
            return "k";
        }
        else if (string.Equals(spriteName, "L_PLetter_IGame") || string.Equals(spriteName, "L_SLetter_IGame") || string.Equals(spriteName, "L_FLetter_IGame"))
        {
            return "l";
        }
        else if (string.Equals(spriteName, "M_PLetter_IGame") || string.Equals(spriteName, "M_SLetter_IGame") || string.Equals(spriteName, "M_FLetter_IGame"))
        {
            return "m";
        }
        else if (string.Equals(spriteName, "N_PLetter_IGame") || string.Equals(spriteName, "N_SLetter_IGame") || string.Equals(spriteName, "N_FLetter_IGame"))
        {
            return "n";
        }
        else if (string.Equals(spriteName, "O_PLetter_IGame") || string.Equals(spriteName, "O_SLetter_IGame") || string.Equals(spriteName, "O_FLetter_IGame"))
        {
            return "o";
        }
        else if (string.Equals(spriteName, "P_PLetter_IGame") || string.Equals(spriteName, "P_SLetter_IGame") || string.Equals(spriteName, "P_FLetter_IGame"))
        {
            return "p";
        }
        else if (string.Equals(spriteName, "Q_PLetter_IGame") || string.Equals(spriteName, "Q_SLetter_IGame") || string.Equals(spriteName, "Q_FLetter_IGame"))
        {
            return "q";
        }
        else if (string.Equals(spriteName, "R_PLetter_IGame") || string.Equals(spriteName, "R_SLetter_IGame") || string.Equals(spriteName, "R_FLetter_IGame"))
        {
            return "r";
        }
        else if (string.Equals(spriteName, "S_PLetter_IGame") || string.Equals(spriteName, "S_SLetter_IGame") || string.Equals(spriteName, "S_FLetter_IGame"))
        {
            return "s";
        }
        else if (string.Equals(spriteName, "T_PLetter_IGame") || string.Equals(spriteName, "T_SLetter_IGame") || string.Equals(spriteName, "T_FLetter_IGame"))
        {
            return "t";
        }
        else if (string.Equals(spriteName, "U_PLetter_IGame") || string.Equals(spriteName, "U_SLetter_IGame") || string.Equals(spriteName, "U_FLetter_IGame"))
        {
            return "u";
        }
        else if (string.Equals(spriteName, "V_PLetter_IGame") || string.Equals(spriteName, "V_SLetter_IGame") || string.Equals(spriteName, "V_FLetter_IGame"))
        {
            return "v";
        }
        else if (string.Equals(spriteName, "W_PLetter_IGame") || string.Equals(spriteName, "W_SLetter_IGame") || string.Equals(spriteName, "W_FLetter_IGame"))
        {
            return "w";
        }
        else if (string.Equals(spriteName, "X_PLetter_IGame") || string.Equals(spriteName, "X_SLetter_IGame") || string.Equals(spriteName, "X_FLetter_IGame"))
        {
            return "x";
        }
        else if (string.Equals(spriteName, "Y_PLetter_IGame") || string.Equals(spriteName, "Y_SLetter_IGame") || string.Equals(spriteName, "Y_FLetter_IGame"))
        {
            return "y";
        }
        else if (string.Equals(spriteName, "Z_PLetter_IGame") || string.Equals(spriteName, "Z_SLetter_IGame") || string.Equals(spriteName, "Z_FLetter_IGame"))
        {
            return "z";
        }
        else if (string.Equals(spriteName, "I_PLetter_IGame") || string.Equals(spriteName, "I_SLetter_IGame") || string.Equals(spriteName, "I_FLetter_IGame"))
        {
            return "i";
        }
        return "";
    }


    public void wordInList()
    {
        //converts the txt file with all the words into a string
        var content = allWords.text;
        var individualWords = content.Split("\n");
        List<string> wordList = new List<string>(individualWords);
        string playerLetter = player.gameObject.GetComponent<SpriteRenderer>().sprite.name;


        bool horizontalContains = wordList.Contains(wordHorizontal);
        bool verticalContains = wordList.Contains(wordVertical);
        bool stoneHorizontalContains = wordList.Contains(stoneWordHorizontal);
        bool stoneVerticalContains = wordList.Contains(stoneWordVertical);


        //makes sure the player letter is deleted
        if (!string.Equals(wordHorizontal, spriteToLetter(playerLetter)) || !string.Equals(wordVertical, spriteToLetter(playerLetter)))
        {
            //checks the list to see if the combined letters make a word in the list
            if (horizontalContains == true)
            {
                isWordInList =  true;
                horizontalWordMade = true;
            }
            if (verticalContains == true)
            {
                isWordInList = true;
                verticalWordMade = true;
            }

            //checks if stonewords are in the list
            if (stoneHorizontalContains == true)
            {
                
                foreach (var letter in letters)
                {
                    if (letter.transform.IsChildOf(player.transform))
                    {
                        if (letter.name[0].Equals('R'))
                        {
                            
                            isWordInList = true;
                            stoneWordMade = true;
                            horizontalWordMade = true;
                        }
                    }
                }
            }
            if (stoneVerticalContains == true)
            {
                foreach (var letter in letters)
                {
                    if (letter.transform.IsChildOf(player.transform))
                    {
                        if (letter.name[0].Equals('R'))
                        {
                            isWordInList = true;
                            stoneWordMade = true;
                            verticalWordMade = true;
                        }
                    }
                }
            }
        }
    }

    IEnumerator fadeOut(SpriteRenderer MyRenderer, float duration, GameObject letter)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame

            yield return new WaitForSeconds(0.00001f);
            if (MyRenderer.color.a < 0.01)
            {
                letter.transform.parent = null;
                letter.transform.position = new Vector3(15f, 15f, 0f);
                yield break;
            }

        }
    }
}

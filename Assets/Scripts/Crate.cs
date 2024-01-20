using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject crate;
    private int crateNumber;
    public GameObject player;
    public bool crateCheck = false;
    private Attach attach;
    float verticalWordLength;
    float horizontalWordLength;

    private bool soundPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        attach = player.GetComponent<Attach>();
    }

    // Update is called once per frame
    void Update()
    {
        crateCheck = attach.crateCheck;
        horizontalWordLength = attach.wordHorizontalLength;
        verticalWordLength = attach.wordVerticalLength;
        if ((crateCheck && verticalWordLength == numberOnCrate()) || (crateCheck && horizontalWordLength == numberOnCrate()))
        {
            if (!soundPlayed) {
                SoundManagerScript.PlaySound("crateUnlock");
                soundPlayed = true;
            }
            crate.transform.position = new Vector3(-10f, -10f, 0f);
        }
    }

    public int numberOnCrate()
    {
        if (crate.name[0].Equals('2'))
        {
            return 2;
        } 
        else if (crate.name[0].Equals('3'))
        {
            return 3;
        }
        else if (crate.name[0].Equals('4'))
        {
            return 4;
        }
        else if (crate.name[0].Equals('5'))
        {
            return 5;
        }
        else if (crate.name[0].Equals('6'))
        {
            return 6;
        }
        else if (crate.name[0].Equals('7'))
        {
            return 7;
        }

        return 0;
    }
}

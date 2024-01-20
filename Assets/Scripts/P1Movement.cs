using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    public GameObject player;
    public Transform movePoint;
    public float moveSpeed;
    public GameObject[] letterMovePoints;
    public LayerMask walls;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

        letterMovePoints = GameObject.FindGameObjectsWithTag("letterPoint");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (checkWall())
            {
                SoundManagerScript.PlaySound("move");
                Debug.Log(Input.GetKeyDown(KeyCode.W));
                movePoint.position += new Vector3(0f, 1f, 0f);
                Debug.Log("movin");
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (checkWall())
            {
                SoundManagerScript.PlaySound("move");
                Debug.Log(Input.GetKeyDown(KeyCode.A));
                movePoint.position += new Vector3(-1f, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if (checkWall())
            {
                SoundManagerScript.PlaySound("move");
                Debug.Log(Input.GetKeyDown(KeyCode.S));
                movePoint.position += new Vector3(0f, -1f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (checkWall())
            {
                SoundManagerScript.PlaySound("move");
                Debug.Log(Input.GetKeyDown(KeyCode.D));
                movePoint.position += new Vector3(1f, 0f, 0f);
            }
        }
    }



    // Creates an invisible circle where the player wants to move. If the circle overlaps with a wall, the player will be unable  to move there.
    public bool checkWall()
    {
        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.3f, walls))
        {
            return false;
        }

        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.3f, walls))
        {
            return false;
        }

        foreach (var letterMovePoint in letterMovePoints)
        {
            if(letterMovePoint.transform.IsChildOf(player.transform))
            {
                if (Physics2D.OverlapCircle(letterMovePoint.transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.3f, walls))
                {
                    Debug.Log("horizontal block");
                    return false;
                }

                if (Physics2D.OverlapCircle(letterMovePoint.transform.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.3f, walls))
                {
                    Debug.Log("vertical block");
                    return false;
                }

                if(Physics2D.OverlapCircle(letterMovePoint.transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f), 0.3f, walls))
                {
                    Debug.Log("horizontal block");
                    return false;
                }
            }
        }
        return true;
    }
}

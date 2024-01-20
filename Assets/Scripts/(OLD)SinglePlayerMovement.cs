using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10f;
    public Transform movePoint;
    public GameObject[] letterMovePoints;
    public GameObject[] letters;
    public LayerMask walls;
    private float upTimeBeforeMoving;
    private float downTimeBeforeMoving;
    private float leftTimeBeforeMoving;
    private float rightTimeBeforeMoving;
    public float timer = 0.25f;
    // Start is called before the first frame update.
    void Start()
    {
        movePoint.parent = null;

        letterMovePoints = GameObject.FindGameObjectsWithTag("letterPoint");

        letters = GameObject.FindGameObjectsWithTag("AttachmentLetter");
    }

    // Update is called once per frame.
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // movement cooldowns
        upTimeBeforeMoving -= Time.deltaTime;
        downTimeBeforeMoving -= Time.deltaTime;
        leftTimeBeforeMoving -= Time.deltaTime;
        rightTimeBeforeMoving -= Time.deltaTime;


        // WASD and arrow movement. Each direction has a cooldown to maintain grid-like movement and prevent continuous sliding. 
        // checkWall function returns true if there is no wall in front.
        
        /* if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            if (Input.GetAxisRaw("Vertical") == 1) {
                if (upTimeBeforeMoving <= 0)
                {
                    if (checkWall())
                    {
                        upTimeBeforeMoving = timer;
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
            if (Input.GetAxisRaw("Vertical") == -1) {
                if (downTimeBeforeMoving <= 0)
                {
                    if(checkWall())
                    {
                        downTimeBeforeMoving = timer;
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 1) {
                if (rightTimeBeforeMoving <= 0)
                {
                    if (checkWall()) 
                    { 
                        rightTimeBeforeMoving = timer;
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
            }
            if (Input.GetAxisRaw("Horizontal") == -1) {
                if (leftTimeBeforeMoving <= 0)
                {
                    if (checkWall())
                    {
                        leftTimeBeforeMoving = timer;
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
            }
        } */
    }



    // Creates an invisible circle where the player wants to move. If the circle overlaps with a wall, the player will be unable to move there.
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
            if (Physics2D.OverlapCircle(letterMovePoint.transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.3f, walls))
            {
                return false;
            }

            if (Physics2D.OverlapCircle(letterMovePoint.transform.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.3f, walls))
            {
                return false;
            }
        }
        return true;
    }
}

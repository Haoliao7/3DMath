using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject warningSquare;
    public float timeBeforeMoving;

    float scaling;
    public float scalingSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("StartMoving", timeBeforeMoving);//wait a certain amount of time and start moving

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= 11 || transform.position.x <= -11)//if it's at the left or right side of the screen
        {
            warningSquare.GetComponent<Transform>().localScale = new Vector3(scaling, 1, 1);//enlarge the width of the warning rectangle
        }


        if (transform.position.y >= 7 || transform.position.y <= -7)//if it's at the top or bottom side of the screen
        {
            warningSquare.GetComponent<Transform>().localScale = new Vector3(1, scaling, 1);//enlarge the height of the warning rectangle
        }

        if (scaling <=50)
        {
            scaling += Time.deltaTime * scalingSpeed;//if it reachs 50, stop scaling
            
        }

        


        if (transform.position.x < -15 || transform.position.x > 15 || transform.position.y > 9 || transform.position.y < -9)
        {
            Destroy(gameObject); // if it moves out, destroy it
        }
        
    }


    void StartMoving()
    {
        if (transform.position.x >= 11)
        {
            rb.velocity = new Vector3(-speed, 0, 0); // if it's at the right side, move left
        }

        if (transform.position.x <= -11)
        {
            rb.velocity = new Vector3(speed, 0, 0);// if it's at the left side, move right
        }

        if (transform.position.y >= 7)
        {
            rb.velocity = new Vector3(0, -speed, 0);// if it's at the top side, move down
        }

        if (transform.position.y <= -7)
        {
            rb.velocity = new Vector3(0, speed, 0);// if it's at the bottom side, move up
        }

    }

}

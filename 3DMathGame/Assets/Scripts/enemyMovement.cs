using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (transform.position.x >= 11)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }

        if (transform.position.x <= -11)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }

        if (transform.position.y >= 7)
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }

        if (transform.position.x <= -7)
        {
            rb.velocity = new Vector3(0, speed, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -15 || transform.position.x > 15 || transform.position.y > 9 || transform.position.y < -9)
        {
            Destroy(gameObject);
        }
        
    }
}

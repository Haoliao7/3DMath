using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xAmplitude;
    public float yAmplitude;

    public float frequency;

    public GameObject range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // the position of mouse
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);//change your mouse position from screen point to world point
        //Debug.Log(mouseWorldPos);

        xAmplitude = map(mouseWorldPos.x, -9, 9, 0f, 8f);
        yAmplitude = map(mouseWorldPos.y, -4.8f, 4.8f, 0f, 4f);


        float x = Mathf.Cos(Time.time * frequency) * xAmplitude;
        float y = Mathf.Sin(Time.time * frequency) * yAmplitude;
        float z = transform.position.z;

       // float scaling = map(Mathf.Sin(Time.time),-1,1,0.5f,1);

        transform.position = new Vector3(x, y, z);
        // transform.localScale = new Vector3(scaling, scaling, scaling);


        range.transform.localScale = new Vector3(xAmplitude*2f, yAmplitude*2f, range.transform.localScale.z);

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }


    float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

}

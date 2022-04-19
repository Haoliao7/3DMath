using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xAmplitude;
    public float yAmplitude;

    public float frequency;
    float rotateSpeed;

    public GameObject range;

    public bool lose;

    public GameObject gameOverStuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // the position of mouse
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);//change your mouse position from screen point to world point
        
        xAmplitude = map(mouseWorldPos.x, -9, 9, 0f, 8f);//map the range of mousePosX to the range between 0 and 8
        yAmplitude = map(mouseWorldPos.y, -4.8f, 4.8f, 0f, 4f);//map the range of mousePosY to the range between 0 and 4

        rotateSpeed += frequency * Time.deltaTime; //rotate speed

        float x = Mathf.Cos(rotateSpeed) * xAmplitude; // use sin and cos to make the object rotate
        float y = Mathf.Sin(rotateSpeed) * yAmplitude;
        float z = transform.position.z;


        transform.position = new Vector3(x, y, z);


        range.transform.localScale = new Vector3(xAmplitude*2f, yAmplitude*2f, range.transform.localScale.z); // make this image as big as the orbit

        if (Input.GetMouseButton(0))
        {
            frequency = 3;//if pressing left button, speed up 
        }
        else 
        {
            frequency = 1; //if releasing, slow down
        }

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy") // if collide with the enemy
        {
            lose = true; // lose
            gameOverStuff.SetActive(true); // activate the game over text
        }
    }


    float map(float value, float leftMin, float leftMax, float rightMin, float rightMax) //mapping function
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

}

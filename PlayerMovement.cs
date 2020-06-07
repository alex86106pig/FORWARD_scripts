using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 8000f;
    public float forwardForceForMobile = 6000f;
    public float sidewaysForce = 150f;
    public float sidewaysForceForMobile = 100f;
    public float jumpForce = 200f;
    public bool playerIsOnTheGround = true;

    private float ScreenWidth;

    //public Button buttonLeft;
    //public Button buttonRight;

    private void Start()
    {
        ScreenWidth = Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Add a foward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //rb.AddForce(0, 0, forwardForceForMobile * Time.deltaTime);

        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                rb.AddForce(sidewaysForceForMobile * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                rb.AddForce(-sidewaysForceForMobile * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            ++i;
        }


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown("space") && playerIsOnTheGround == true)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            playerIsOnTheGround = false;
        }

        if (rb.position.y < -1f)
        {
            //FindObjectOfType<GameManager>().EndGame();
            PlayerCollision.IsGameOvered = true;
        }
        if (rb.position.x < -11f)
        {
            //FindObjectOfType<GameManager>().EndGame();
            PlayerCollision.IsGameOvered = true;
        }
        if (rb.position.x > 11f)
        {
            //FindObjectOfType<GameManager>().EndGame();
            PlayerCollision.IsGameOvered = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }
    }
    
    

    /*public void MoveLeft()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }*/

}

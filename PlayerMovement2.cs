using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour
{

    public Rigidbody rb;

    private float ScreenWidth;

    //public Transform wall1;
    //public Transform wall2;
    //public Transform wall3;
    //public Transform wall4;
    //public float forwardForce = 2000f;
    //public float sidewaysForce = 500f;
    //public float jumpForce = 200f;
    public bool playerIsOnTheGround = true;
    public float moveTime = 0.2f;

   //public Button MoveLeft;
    //public KeyCode moveL; //讓鍵盤可以輸入，要輸入甚麼要到Unity裡面設定
    //public KeyCode moveR;

    public float horizVel = 0; //X軸
    //public int laneNum = 2; //左邊1中間2右邊3
    //public string controllocked = "n"; //讓玩家不能在球還在動的時候又輸入新的動作的變數

    string nextKey;

    public PlayerMovement2()
    {
        statMachine = new StatMachine(this);
    }

    private StatMachine statMachine;

    enum Status { waitInput, updatePosition }

    private class StatMachine
    {
        PlayerMovement2 instance;
        Status stat = Status.waitInput;
        float startTime;
        float endTime;
        float originX = 0f;
        float wantX = 0f;
        float originY = 1f;
        float wantY = 1f;
        

        public StatMachine(PlayerMovement2 instance) {
            this.instance = instance;
        }

        public bool Is(Status stat)
        {
            return this.stat == stat;
        }

        public void InputLeft()
        {
            updateInput(-1f, 0f);
        }

        public void InputRight()
        {
            updateInput(1f, 0f);
        }

        public void InputUp()
        {
            updateInput(0f, 1f);
        }

        public void InputDown()
        {
            updateInput(0f, -1f);
        }

        private void updateInput(float deltaX, float deltaY)
        {
            
            startTime = Time.time;
            endTime = startTime + instance.moveTime;
            originX = instance.GetComponent<Transform>().position.x;
            wantX = originX + deltaX;
            originY = instance.GetComponent<Transform>().position.y;
            wantY = originY + deltaY;

            int ix = (int)(wantX * 10000f);
            int iy = (int)(wantY * 10000f);

            if(ix > 10000 || ix < -10000)
            {
                return;
            }
            if (iy > 30000 || iy < 10000)
            {
                return;
            }
            stat = Status.updatePosition;
        }

        public void DoUpdatePosition()
        {
            float now = Time.time;
            float x = Mathf.Lerp(originX, wantX, (now - startTime) / instance.moveTime);
            float y = Mathf.Lerp(originY, wantY, (now - startTime) / instance.moveTime);

            if (now >= endTime)
            {
                x = wantX;
                y = wantY;
                stat = Status.waitInput;
            }

            

            instance.gameObject.transform.position = new Vector3(x, y, instance.GetComponent<Transform>().position.z);

        }

    }

    //void MoveLeft()
   // {

   // }

    String GetKey()
    {

        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                return "d";
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                return "a";
            }
            ++i;
        }

        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {

            return "a";
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {

            return "d";
        }
        else if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {

            return "w";
        }
        else if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {

            return "s";
        }
        return null;

    }

    public void Start()
    {
        //Button btn = MoveLeft.GetComponent<Button>();
        GetComponent<Rigidbody>().velocity = new Vector3(0, GameManager.vertVel, 20); //讓球有定速往前
        ScreenWidth = Screen.width;
    }

    void Update()
    {

        if (statMachine.Is(Status.waitInput))
        {
            string key = GetKey();

            if (key == "a")
            {              
                statMachine.InputLeft();
            }
            if (key == "d")
            {
                statMachine.InputRight();
            }
            if (key == "w")
            {            
                statMachine.InputUp();
            }
            if (key == "s")
            {               
                statMachine.InputDown();
            }
        }

        if (statMachine.Is(Status.updatePosition))
        {

            statMachine.DoUpdatePosition();
        }

        

        // Add a foward force
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        
        //rb.AddForce(horizVel * Time.deltaTime, GameManager.vertVel * Time.deltaTime, forwardForce * Time.deltaTime);

        /*if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            this.gameObject.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            this.gameObject.transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            this.gameObject.transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            this.gameObject.transform.position += new Vector3(1, 0, 0);
        }

        /*if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && (controllocked == "n"))
        {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controllocked = "y";
            GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GameManager.vertVel, 15); //讓球有定速往前
        } else  if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controllocked == "n"))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controllocked = "y";
            GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GameManager.vertVel, 15);
        } else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        velocity.x = Mathf.Lerp(velocity.x, speed * xInput, deltatime * acceleration);
        */

    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }
    }

    /*IEnumerator StopSlide() //可能要找個人問問這個得更多用法
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controllocked = "n";
    }*/

}

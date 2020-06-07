using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBgColor : MonoBehaviour
{
    public Transform player;

    public Color color0 = new Color32(0, 0, 0, 0);
    public Color color1 = new Color32(0, 0, 0, 0);
    public Color color2 = new Color32(0, 0, 0, 0);
    public Color color3 = new Color32(0, 0, 0, 0);

    public float mileStone0 = 0.0f;
    public float mileStone1 = 500.0f;
    public float mileStone2 = 1000.0f;
    public float mileStone3 = 1500.0f;

    public float deltaTime = 1.0f;

    //public float duration = 3.0F;

    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        //cam.clearFlags = CameraClearFlags.SolidColor;

        if (player.position.z == mileStone0)
        {
            cam.backgroundColor = color0;
        }
      
    }

    void Update()
    {

        //float t = Mathf.PingPong(Time.time, duration) / duration;
        if (player.position.z == mileStone1)
        {
            cam.backgroundColor = Color.Lerp(color0, color1, deltaTime);
        }
        if (player.position.z == mileStone2)
        {
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = color2;
        }
        if (player.position.z == mileStone3)
        {
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = color3;
        }

    }
    //2 seconds within each transition/Can change from the Editor
    /*public float transitionTimeInSec = 2f;

    private bool changingColor = false;

    private Color color1;
    private Color color2;


    void Start()
    {
        StartCoroutine(beginToChangeColor());
    }

    IEnumerator beginToChangeColor()
    {
        Camera cam = Camera.main;
        color1 = Random.ColorHSV(Random.value, Random.value);
        color2 = Random.ColorHSV(Random.value, Random.value);

        while (true)
        {
            //Lerp Color and wait here until that's done
            yield return lerpColor(cam, color1, color2, transitionTimeInSec);

            //Generate new color
            color1 = cam.backgroundColor;
            color2 = Random.ColorHSV(Random.value, Random.value);
        }
    }

    IEnumerator lerpColor(Camera targetCamera, Color fromColor, Color toColor, float duration)
    {
        if (changingColor)
        {
            yield break;
        }
        changingColor = true;
        float counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float colorTime = counter / duration;
            Debug.Log(colorTime);

            //Change color
            targetCamera.backgroundColor = Color.Lerp(fromColor, toColor, counter / duration);
            //Wait for a frame
            yield return null;
        }
        changingColor = false;
    }*/
}

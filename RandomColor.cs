using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    private void Start()
    {
        int i = Random.Range(1, 4);

        if (i == 1)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(0, 236, 250, 198);//blue
        }

        if (i == 2)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(250, 237, 0, 198);//yellow
        }

        //if (i == 3)
        //{
            //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(0, 250, 100, 198);
        //}

        //if (i == 4)
        //{
            //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(255, 55, 21, 198);
        //}

        if (i == 3)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(236, 59, 255, 198);//purple
        }


    }
 
}

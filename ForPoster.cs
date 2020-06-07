using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPoster : MonoBehaviour
{
    public Transform obstacle2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacle2, new Vector3(0, 2, 100), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerForParticle : MonoBehaviour
{
    public Transform Player;
    //public Transform Player2;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, Player.position.z) + offset;
        //transform.position = Player2.position + offset;
    }
}

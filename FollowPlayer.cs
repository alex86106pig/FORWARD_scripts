using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Player;
    //public Transform Player2;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position + offset;
        //transform.position = Player2.position + offset;
    }
}

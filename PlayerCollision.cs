using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerMovement2 movement2;
    public static bool IsGameOvered = false;

    void OnCollisionEnter (Collision collisionInfo) //Unity自己內建的碰撞函式
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            movement2.enabled = false;

            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            IsGameOvered = true;
            //FindObjectOfType<GameManager>().EndGame();
        }

    }

}

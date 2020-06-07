using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //public static bool gameHasEnded = false;

    //public float restartDelay = 1f;

    public GameObject levelCompleteUI;

    public static float vertVel = 0;

    public void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
    }

    /*public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            //Invoke("Restart", restartDelay);
        }
    }*/

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

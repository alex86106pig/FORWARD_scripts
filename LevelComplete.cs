using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //這個是要有下一關的做法，build settings那邊每個Scene有編號，用那個編號一直跑下一關下一關這樣
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartLevel1()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(2);
    }
    public void StartLevel2()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(3);
    }
    public void StartLevel3()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(4);
    }
    public void StartLevel4()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(5);
    }
    public void StartLevel5()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(6);
    }
    public void StartLevel6()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(7);
    }
    public void StartLevel7()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(8);
    }
    public void StartLevel8()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(9);
    }
    public void StartLevel9()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(10);
    }
    public void StartLevel10()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(11);
    }
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

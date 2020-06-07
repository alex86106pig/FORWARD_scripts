using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public Transform player2;
    public Text highScore;


    void Start()
    {
        //highScore = GetComponent<TextMeshProUGUI>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        int highscore = (int)(player2.position.z);

        if (highscore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", highscore);
            highScore.text = highscore.ToString();
        }

    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}

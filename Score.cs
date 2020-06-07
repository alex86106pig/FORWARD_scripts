using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public Transform player;
    public float score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score = player.position.z;
        scoreText.text = score.ToString("0"); //text是儲存string，但是transform是float所以要轉成string
                                                          //"0"是為了不要有小數點，但是我也不知道為甚麼這樣就可以
    }
}

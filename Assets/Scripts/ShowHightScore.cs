using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;

    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "Рекорд: " + highScore.ToString();
        }
        else
        {
            Debug.LogWarning("HighScoreText не назначен в инспекторе!");
        }
    }
}

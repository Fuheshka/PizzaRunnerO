using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreText; // Текущий счёт
    [SerializeField] private TextMeshProUGUI highScoreText; // Текст для лучшего счёта
    private float score;    // Текущее количество очков
    private int highScore;  // Лучший счёт
    private bool isRunning; // Флаг активности игры

    [SerializeField] private float scorePerSecond = 10f; // Очков за секунду

    void Start()
    {
        // Получаем компонент TextMeshProUGUI с того объекта, на котором скрипт
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0f;
        isRunning = true;

        // Загружаем лучший счёт из PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0); // 0 — значение по умолчанию
        UpdateHighScoreText();
        UpdateScoreText();
    }

    void Update()
    {
        if (isRunning)
        {
            // Увеличиваем очки на основе времени
            score += scorePerSecond * Time.deltaTime;
            UpdateScoreText();

            // Проверяем, не побили ли текущий счёт рекорд
            int currentScore = Mathf.FloorToInt(score);
            if (currentScore > highScore)
            {
                highScore = currentScore;
                UpdateHighScoreText();
                PlayerPrefs.SetInt("HighScore", highScore); // Сохраняем новый рекорд
                PlayerPrefs.Save();
            }
        }
    }

    // Метод для обновления отображаемого текста текущего счёта
    private void UpdateScoreText()
    {
        scoreText.text = "Очки: " + Mathf.FloorToInt(score).ToString();
    }

    // Метод для обновления отображаемого текста лучшего счёта
    private void UpdateHighScoreText()
    {

        highScoreText.text = "Рекорд: " + highScore.ToString();

    }

    // Метод для остановки подсчёта (вызывается при проигрыше)
    public void StopScoring()
    {
        isRunning = false;
    }

    // Метод для получения текущего счёта
    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    // Метод для сброса текущего счёта
    public void ResetScore()
    {
        score = 0f;
        isRunning = true;
        UpdateScoreText();
    }

    // Метод для сброса лучшего счёта (опционально, для отладки или настроек)
    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
        UpdateHighScoreText();
    }
}
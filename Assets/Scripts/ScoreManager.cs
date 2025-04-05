using TMPro;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI Text

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreText; // Ссылка на компонент Text
    private float score;    // Текущее количество очков
    private bool isRunning; // Флаг активности игры

    [SerializeField]        // Позволяет задавать значение в инспекторе
    private float scorePerSecond = 10f; // Очков за секунду

    void Start()
    {
        // Получаем компонент Text с того объекта, на котором скрипт
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0f;
        isRunning = true;

        // Устанавливаем начальное значение
        UpdateScoreText();
    }

    void Update()
    {
        if (isRunning)
        {
            // Увеличиваем очки на основе времени
            score += scorePerSecond * Time.deltaTime;
            UpdateScoreText();
        }
    }

    // Метод для обновления отображаемого текста
    private void UpdateScoreText()
    {
        // Округляем до целого числа и обновляем текст
        scoreText.text = "Очки: " + Mathf.FloorToInt(score).ToString();
    }

    // Метод для остановки подсчета (можно вызвать при проигрыше)
    public void StopScoring()
    {
        isRunning = false;
    }

    // Метод для получения текущего счета
    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    // Метод для сброса счета
    public void ResetScore()
    {
        score = 0f;
        isRunning = true;
        UpdateScoreText();
    }
}

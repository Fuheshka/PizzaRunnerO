using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button pauseButton; // Кнопка паузы
    [SerializeField] private Button resumeButton; // Кнопка возобновления

    private bool isPaused = false; // Флаг состояния паузы

    void Start()
    {
        // Устанавливаем начальное состояние кнопок
        if (pauseButton != null)
        {
            pauseButton.gameObject.SetActive(true);
            pauseButton.onClick.AddListener(PauseGame);
        }
        if (resumeButton != null)
        {
            resumeButton.gameObject.SetActive(false);
            resumeButton.onClick.AddListener(ResumeGame);
        }
    }

    // Метод для паузы игры
    private void PauseGame()
    {
        Time.timeScale = 0f; // Останавливаем время
        isPaused = true;
        Debug.Log("Game Paused");

        // Переключаем видимость кнопок
        if (pauseButton != null) pauseButton.gameObject.SetActive(false);
        if (resumeButton != null) resumeButton.gameObject.SetActive(true);
    }

    // Метод для возобновления игры
    private void ResumeGame()
    {
        Time.timeScale = 1f; // Возобновляем время
        isPaused = false;
        Debug.Log("Game Resumed");

        // Переключаем видимость кнопок
        if (pauseButton != null) pauseButton.gameObject.SetActive(true);
        if (resumeButton != null) resumeButton.gameObject.SetActive(false);
    }
}
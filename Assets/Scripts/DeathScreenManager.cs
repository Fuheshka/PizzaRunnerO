using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenManager : MonoBehaviour
{
    [SerializeField] private Button Restart; // Кнопка "Перезапуск"
    [SerializeField] private Button Exit;    // Кнопка "Меню"
    [SerializeField] private Button Pause;    // Кнопка "Меню"

    private void Awake()
    {
        // Привяжем методы к кнопкам
        Restart.onClick.AddListener(RestartGame);
        Exit.onClick.AddListener(GoToMenu);
    }

    private void OnEnable()
    {
        // Останавливаем игру (ставим на паузу) при активации DeathScreen
        Time.timeScale = 0f;
        // Скрываем кнопку паузы
        if (Pause != null)
        {
            Pause.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Pause button is not assigned!");
        }
    }

    private void OnDisable()
    {
        // Возвращаем нормальное течение времени при деактивации DeathScreen
        Time.timeScale = 1f;
    }

    // Метод для перезапуска игры
    private void RestartGame()
    {
        Time.timeScale = 1f; // Снимаем паузу
        SceneManager.LoadScene(0); // Загружаем основную сцену
    }

    // Метод для перехода в меню
    private void GoToMenu()
    {
        Time.timeScale = 1f; // Снимаем паузу
        SceneManager.LoadScene(1); // Загружаем сцену меню
    }
}
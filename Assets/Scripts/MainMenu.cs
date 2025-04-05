using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Start; // Кнопка "Старт"
    [SerializeField] private Button Settings;    // Кнопка "Настройки"

    private void Awake()
    {
        // Привяжем методы к кнопкам
        Start.onClick.AddListener(StartGame);
        Settings.onClick.AddListener(GoToSettings);
    }

    // Метод для перезапуска игры
    private void StartGame()
    {
        SceneManager.LoadScene(0); // Загружаем основную сцену
    }

    // Метод для перехода в меню
    private void GoToSettings()
    {
        SceneManager.LoadScene(1); // Загружаем сцену меню
    }
}

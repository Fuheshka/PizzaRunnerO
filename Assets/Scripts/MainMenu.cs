using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DeathScreenManager;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Start; // Кнопка "Старт"



    private void Awake()
    {
        // Привяжем методы к кнопкам
        Start.onClick.AddListener(StartGame);
    }

    // Метод для перезапуска игры
    private void StartGame()
    {
        SceneManager.LoadScene(0); // Загружаем основную сцену
    }


}

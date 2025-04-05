using UnityEngine;
using UnityEngine.UI; // Для работы с UI (кнопками)


public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas; // Ссылка на MainMenuCanvas
    [SerializeField] private GameObject settingsCanvas; // Ссылка на SettingsCanvas

    [SerializeField] private Button toSettingsButton; // Кнопка для перехода в настройки
    [SerializeField] private Button backToMainMenuButton; // Кнопка для возврата в главное меню

    void Start()
    {
        // Устанавливаем начальное состояние
        if (mainMenuCanvas != null) mainMenuCanvas.SetActive(true);
        if (settingsCanvas != null) settingsCanvas.SetActive(false);

        // Привязываем методы к кнопкам
        if (toSettingsButton != null)
        {
            toSettingsButton.onClick.AddListener(ShowSettings);
        }


        if (backToMainMenuButton != null)
        {
            backToMainMenuButton.onClick.AddListener(ShowMainMenu);
        }

    }

    // Метод для показа настроек
    private void ShowSettings()
    {
        if (mainMenuCanvas != null) mainMenuCanvas.SetActive(false);
        if (settingsCanvas != null) settingsCanvas.SetActive(true);
    }

    // Метод для возврата в главное меню
    private void ShowMainMenu()
    {
        if (mainMenuCanvas != null) mainMenuCanvas.SetActive(true);
        if (settingsCanvas != null) settingsCanvas.SetActive(false);
    }
}
using UnityEngine;
using UnityEngine.UI; // Для работы с UI (кнопками)

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas; // Ссылка на MainMenuCanvas
    [SerializeField] private Canvas settingsCanvas; // Ссылка на SettingsCanvas

    [SerializeField] private Button toSettingsButton; // Кнопка для перехода в настройки
    [SerializeField] private Button backToMainMenuButton; // Кнопка для возврата в главное меню

    void Start()
    {
        // Устанавливаем начальное состояние
        if (mainMenuCanvas != null) mainMenuCanvas.enabled = true;
        if (settingsCanvas != null) settingsCanvas.enabled = false;

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
        if (mainMenuCanvas != null) mainMenuCanvas.enabled = false;
        if (settingsCanvas != null) settingsCanvas.enabled = true;
    }

    // Метод для возврата в главное меню
    private void ShowMainMenu()
    {
        if (mainMenuCanvas != null) mainMenuCanvas.enabled = true;
        if (settingsCanvas != null) settingsCanvas.enabled = false;
    }
}
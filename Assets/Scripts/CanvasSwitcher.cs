using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI (��������)

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas; // ������ �� MainMenuCanvas
    [SerializeField] private Canvas settingsCanvas; // ������ �� SettingsCanvas

    [SerializeField] private Button toSettingsButton; // ������ ��� �������� � ���������
    [SerializeField] private Button backToMainMenuButton; // ������ ��� �������� � ������� ����

    void Start()
    {
        // ������������� ��������� ���������
        if (mainMenuCanvas != null) mainMenuCanvas.enabled = true;
        if (settingsCanvas != null) settingsCanvas.enabled = false;

        // ����������� ������ � �������
        if (toSettingsButton != null)
        {
            toSettingsButton.onClick.AddListener(ShowSettings);
        }


        if (backToMainMenuButton != null)
        {
            backToMainMenuButton.onClick.AddListener(ShowMainMenu);
        }

    }

    // ����� ��� ������ ��������
    private void ShowSettings()
    {
        if (mainMenuCanvas != null) mainMenuCanvas.enabled = false;
        if (settingsCanvas != null) settingsCanvas.enabled = true;
    }

    // ����� ��� �������� � ������� ����
    private void ShowMainMenu()
    {
        if (mainMenuCanvas != null) mainMenuCanvas.enabled = true;
        if (settingsCanvas != null) settingsCanvas.enabled = false;
    }
}
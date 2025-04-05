using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI (��������)


public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas; // ������ �� MainMenuCanvas
    [SerializeField] private GameObject settingsCanvas; // ������ �� SettingsCanvas

    [SerializeField] private Button toSettingsButton; // ������ ��� �������� � ���������
    [SerializeField] private Button backToMainMenuButton; // ������ ��� �������� � ������� ����

    void Start()
    {
        // ������������� ��������� ���������
        if (mainMenuCanvas != null) mainMenuCanvas.SetActive(true);
        if (settingsCanvas != null) settingsCanvas.SetActive(false);

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
        if (mainMenuCanvas != null) mainMenuCanvas.SetActive(false);
        if (settingsCanvas != null) settingsCanvas.SetActive(true);
    }

    // ����� ��� �������� � ������� ����
    private void ShowMainMenu()
    {
        if (mainMenuCanvas != null) mainMenuCanvas.SetActive(true);
        if (settingsCanvas != null) settingsCanvas.SetActive(false);
    }
}
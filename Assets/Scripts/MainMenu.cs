using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Start; // ������ "�����"
    [SerializeField] private Button Settings;    // ������ "���������"

    private void Awake()
    {
        // �������� ������ � �������
        Start.onClick.AddListener(StartGame);
        Settings.onClick.AddListener(GoToSettings);
    }

    // ����� ��� ����������� ����
    private void StartGame()
    {
        SceneManager.LoadScene(0); // ��������� �������� �����
    }

    // ����� ��� �������� � ����
    private void GoToSettings()
    {
        SceneManager.LoadScene(1); // ��������� ����� ����
    }
}

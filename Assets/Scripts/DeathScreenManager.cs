using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenManager : MonoBehaviour
{
    [SerializeField] private Button Restart; // ������ "����������"
    [SerializeField] private Button Exit;    // ������ "����"
    [SerializeField] private Button Pause;    // ������ "����"

    private void Awake()
    {
        // �������� ������ � �������
        Restart.onClick.AddListener(RestartGame);
        Exit.onClick.AddListener(GoToMenu);
    }

    private void OnEnable()
    {
        // ������������� ���� (������ �� �����) ��� ��������� DeathScreen
        Time.timeScale = 0f;
        // �������� ������ �����
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
        // ���������� ���������� ������� ������� ��� ����������� DeathScreen
        Time.timeScale = 1f;
    }

    // ����� ��� ����������� ����
    private void RestartGame()
    {
        Time.timeScale = 1f; // ������� �����
        SceneManager.LoadScene(0); // ��������� �������� �����
    }

    // ����� ��� �������� � ����
    private void GoToMenu()
    {
        Time.timeScale = 1f; // ������� �����
        SceneManager.LoadScene(1); // ��������� ����� ����
    }
}
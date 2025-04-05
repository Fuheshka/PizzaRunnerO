using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button pauseButton; // ������ �����
    [SerializeField] private Button resumeButton; // ������ �������������

    private bool isPaused = false; // ���� ��������� �����

    void Start()
    {
        // ������������� ��������� ��������� ������
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

    // ����� ��� ����� ����
    private void PauseGame()
    {
        Time.timeScale = 0f; // ������������� �����
        isPaused = true;
        Debug.Log("Game Paused");

        // ����������� ��������� ������
        if (pauseButton != null) pauseButton.gameObject.SetActive(false);
        if (resumeButton != null) resumeButton.gameObject.SetActive(true);
    }

    // ����� ��� ������������� ����
    private void ResumeGame()
    {
        Time.timeScale = 1f; // ������������ �����
        isPaused = false;
        Debug.Log("Game Resumed");

        // ����������� ��������� ������
        if (pauseButton != null) pauseButton.gameObject.SetActive(true);
        if (resumeButton != null) resumeButton.gameObject.SetActive(false);
    }
}
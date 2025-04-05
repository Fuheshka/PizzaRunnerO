using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DeathScreenManager;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Start; // ������ "�����"



    private void Awake()
    {
        // �������� ������ � �������
        Start.onClick.AddListener(StartGame);
    }

    // ����� ��� ����������� ����
    private void StartGame()
    {
        SceneManager.LoadScene(0); // ��������� �������� �����
    }


}

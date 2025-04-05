using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance; // �������� ��� ������� �� ������ ����

    private const string SKIN_KEY = "SelectedSkin"; // ���� ��� ���������� �����
    private const string HIGH_SCORE_KEY = "HighScore"; // ���� ��� �������
    private string selectedSkin = "Default"; // ������� ��������� ���� (�� ��������� � �����������)

    void Awake()
    {
        // ���������� ���������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������
        }
        else
        {
            Destroy(gameObject);
        }

        // ��������� ���������� ����
        LoadSkin();
    }

    // ���������, �������� �� ������� ����
    public bool IsRedSkinUnlocked()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        return false/*highScore >= 200*/;
    }

    // �������� ������� ����
    public void SelectRedSkin()
    {
        if (IsRedSkinUnlocked())
        {
/*            selectedSkin = "Red";
            PlayerPrefs.SetString(SKIN_KEY, selectedSkin);
            PlayerPrefs.Save();
            Debug.Log("Red skin selected!");*/
        }
        else
        {
            Debug.Log("Red skin is locked! Need a high score of 1000 or more.");
        }
    }

    // �������� ������� ��������� ����
    public string GetSelectedSkin()
    {
        return selectedSkin;
    }

    // ��������� ���������� ����
    private void LoadSkin()
    {
        selectedSkin = PlayerPrefs.GetString(SKIN_KEY, "Default"); // �� ��������� � ����������� ����
    }
}
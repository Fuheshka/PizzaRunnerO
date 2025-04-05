using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{

    public static SkinSelector Instance; // �������� ��� ������� �� ������ ����

    [SerializeField] private Button defoultSkinButton; // ������ ��� ������ �������� �����
    [SerializeField] private Button redSkinButton; // ������ ��� ������ �������� �����

    private const string SKIN_KEY = "SelectedSkin"; // ���� ��� ���������� �����
    private const string HIGH_SCORE_KEY = "HighScore"; // ���� ��� �������
    private string selectedSkin = "Default"; // ������� ��������� ���� (�� ��������� � �����������)
    void Start()
    {
        // ��������� ���������� ����
        selectedSkin = PlayerPrefs.GetString(SKIN_KEY, "Default");

        if (redSkinButton != null)
        {
            redSkinButton.onClick.AddListener(SelectRedSkin);
            defoultSkinButton.onClick.AddListener(SelectDefoultSkin);
        }

        // ��������� ��������� ������
        IsRedSkinUnlocked();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���������, �������� �� ������� ����
    public bool IsRedSkinUnlocked()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        redSkinButton.interactable = (highScore >= 1000);
        return highScore >= 1000;
        
    }

    public void SelectRedSkin()
    {
        if (IsRedSkinUnlocked())
        {
            selectedSkin = "Red";
            PlayerPrefs.SetString(SKIN_KEY, selectedSkin);
            PlayerPrefs.Save();
            Debug.Log("Red skin selected!");
        }
        else
        {
            redSkinButton.GetComponentInChildren<TextMeshProUGUI>().text = "����� 1000 �����";
            Debug.Log("Red skin is locked! Need a high score of 1000 or more.");
        }
    }

    public void SelectDefoultSkin()
    {
        selectedSkin = "Default";
        PlayerPrefs.SetString(SKIN_KEY, selectedSkin);
        PlayerPrefs.Save();
        Debug.Log("Simple skin selected!");
    }
}
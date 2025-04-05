using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{

    public static SkinSelector Instance; // Синглтон для доступа из других сцен

    [SerializeField] private Button defoultSkinButton; // Кнопка для выбора красного скина
    [SerializeField] private Button redSkinButton; // Кнопка для выбора красного скина

    private const string SKIN_KEY = "SelectedSkin"; // Ключ для сохранения скина
    private const string HIGH_SCORE_KEY = "HighScore"; // Ключ для рекорда
    private string selectedSkin = "Default"; // Текущий выбранный скин (по умолчанию — стандартный)
    void Start()
    {
        // Загружаем сохранённый скин
        selectedSkin = PlayerPrefs.GetString(SKIN_KEY, "Default");

        if (redSkinButton != null)
        {
            redSkinButton.onClick.AddListener(SelectRedSkin);
            defoultSkinButton.onClick.AddListener(SelectDefoultSkin);
        }

        // Обновляем состояние кнопки
        IsRedSkinUnlocked();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Проверяем, доступен ли красный скин
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
            redSkinButton.GetComponentInChildren<TextMeshProUGUI>().text = "Нужно 1000 очков";
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
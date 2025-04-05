using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance; // Синглтон для доступа из других сцен

    private const string SKIN_KEY = "SelectedSkin"; // Ключ для сохранения скина
    private const string HIGH_SCORE_KEY = "HighScore"; // Ключ для рекорда
    private string selectedSkin = "Default"; // Текущий выбранный скин (по умолчанию — стандартный)

    void Awake()
    {
        // Реализация синглтона
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            Destroy(gameObject);
        }

        // Загружаем сохранённый скин
        LoadSkin();
    }

    // Проверяем, доступен ли красный скин
    public bool IsRedSkinUnlocked()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        return false/*highScore >= 200*/;
    }

    // Выбираем красный скин
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

    // Получаем текущий выбранный скин
    public string GetSelectedSkin()
    {
        return selectedSkin;
    }

    // Загружаем сохранённый скин
    private void LoadSkin()
    {
        selectedSkin = PlayerPrefs.GetString(SKIN_KEY, "Default"); // По умолчанию — стандартный скин
    }
}
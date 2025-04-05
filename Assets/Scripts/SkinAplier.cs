using UnityEngine;

public class PlayerColorApplier : MonoBehaviour
{
    private Renderer renderer;
    private Color defaultColor = Color.white; // Стандартный цвет
    private Color redColor = Color.red;       // Красный цвет для скина

    void Start()
    {
        renderer = GetComponent<Renderer>();
        ApplyColor();
    }

    private void ApplyColor()
    {
        string selectedSkin = PlayerPrefs.GetString("SelectedSkin", "");
        if (selectedSkin == "Red")
        {
            renderer.material.color = redColor;
            Debug.Log("Applied red color to player!");
        }
        else
        {
            renderer.material.color = defaultColor;
            Debug.Log("Applied default color to player!");
        }
    }
}
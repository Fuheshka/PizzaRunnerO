using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteMenu : MonoBehaviour
{
    [Header("2D Buttons")]
    [SerializeField] private SpriteRenderer startButton;
    [SerializeField] private SpriteRenderer settingsButton;
    
    [Header("Button Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite hoverSprite;
    
    [Header("Camera Settings")]
    [SerializeField] private Camera menuCamera;
    [SerializeField] private float orthoSize = 5f;
    
    private void Start()
    {
        SetupCamera();
    }
    
    private void Update()
    {
        HandleButtonInteraction();
    }
    
    private void SetupCamera()
    {
        if (menuCamera != null)
        {
            // Делаем камеру ортографической для 2D
            menuCamera.orthographic = true;
            menuCamera.orthographicSize = orthoSize;
            
            // Центрируем камеру на меню
            menuCamera.transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                menuCamera.transform.position.z
            );
        }
    }
    
    private void HandleButtonInteraction()
    {
        // Для мобильных устройств
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckTouch(Input.GetTouch(0).position);
        }
        // Для редактора/тестирования
        else if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
    }
    
    private void CheckTouch(Vector2 screenPosition)
    {
        Vector2 worldPoint = menuCamera.ScreenToWorldPoint(screenPosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);
        
        if (hit != null)
        {
            if (hit.gameObject == startButton.gameObject)
            {
                StartCoroutine(ButtonPressEffect(startButton));
                StartGame();
            }
            else if (hit.gameObject == settingsButton.gameObject)
            {
                StartCoroutine(ButtonPressEffect(settingsButton));
                OpenSettings();
            }
        }
    }
    
    private System.Collections.IEnumerator ButtonPressEffect(SpriteRenderer button)
    {
        button.sprite = hoverSprite;
        yield return new WaitForSeconds(0.1f);
        button.sprite = normalSprite;
    }
    
    private void StartGame()
    {
        Debug.Log("Starting game...");
        SceneManager.LoadScene("GameScene");
    }
    
    private void OpenSettings()
    {
        Debug.Log("Opening settings...");
        // Здесь можно активировать панель настроек
    }
}
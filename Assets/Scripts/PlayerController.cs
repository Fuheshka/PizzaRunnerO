using UnityEngine;
using UnityEngine.UIElements;
using Dreamteck.Forever;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    LaneRunner runner;

    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    [SerializeField] private float rayRange = 1.1f;
    [SerializeField] private float jumpHeight = 5f; // Высота прыжка
    [SerializeField] private float jumpDuration = 0.6f; // Длительность прыжка

    private bool isRotating = false;
    private float rotationTime = 0f;
    private float rotationDuration = 0.5f;

    private bool isJumping = false; // Флаг прыжка
    private float jumpTime = 0f; // Текущее время прыжка

    [SerializeField] private GameObject deathScreen; // Ссылка на DeathScreen

    private void Start()
    {
        runner = GetComponent<LaneRunner>();
        if (runner == null)
        {
            Debug.LogError("LaneRunner component not found on this GameObject!");
        }

        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
        }
    }

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        #region ПК-версия
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Мобильная версия
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        // Просчитать дистанцию
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Проверка на пройденность расстояния
        if (swipeDelta.magnitude > 100)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    runner.lane++;
                else
                    runner.lane--;
            }
            else
            {
                if (y < 0)
                {
                    isRotating = true;
                    rotationTime = 0f;
                }
                else
                {
                    swipeUp = true;
                    if (!isJumping) // Начинаем прыжок, только если он ещё не идёт
                    {
                        isJumping = true;
                        jumpTime = 0f;
                    }
                }
            }

            Reset();
        }


        // Логика вращения
        if (isRotating)
        {
            rotationTime += Time.deltaTime;
            if (rotationTime < rotationDuration / 2f)
            {
                float t = rotationTime / (rotationDuration / 2f);
                runner.motion.rotationOffset = Vector3.Lerp(Vector3.zero, new Vector3(-70, 0, 0), t);
            }
            else if (rotationTime < rotationDuration)
            {
                float t = (rotationTime - rotationDuration / 2f) / (rotationDuration / 2f);
                runner.motion.rotationOffset = Vector3.Lerp(new Vector3(-70, 0, 0), Vector3.zero, t);
            }
            else
            {
                runner.motion.rotationOffset = Vector3.zero;
                isRotating = false;
                rotationTime = 0f;
            }
        }

        // Логика прыжка с использованием runner
        if (isJumping)
        {
            jumpTime += Time.deltaTime;
            float heightOffset = 0f;

            if (jumpTime < jumpDuration / 2f) // Подъём
            {
                float t = jumpTime / (jumpDuration / 2f);
                heightOffset = Mathf.Lerp(0f, jumpHeight, t);
            }
            else if (jumpTime < jumpDuration) // Спуск
            {
                float t = (jumpTime - jumpDuration / 2f) / (jumpDuration / 2f);
                heightOffset = Mathf.Lerp(jumpHeight, 0f, t);
            }
            else // Завершение прыжка
            {
                heightOffset = 0f;
                isJumping = false;
                jumpTime = 0f;
            }

            // Применяем смещение через runner.motion.offset
            runner.motion.offset = new Vector3(-6f, heightOffset + 1, 0f);
        }

        // Raycast
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * rayRange));

        if (Physics.Raycast(theRay, out RaycastHit hit, rayRange))
        {
            if (hit.collider.tag == "Obstacle")
            {
                deathScreen.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
            SceneManager.LoadScene(0);
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
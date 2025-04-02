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

    private void Start()
    {
        runner = GetComponent<LaneRunner>();
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

        //Просчитать дистанцию
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Проверка на пройденность расстояния
        if (swipeDelta.magnitude > 100)
        {
            //Определение направления
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                if (x < 0)
                    runner.lane--;
                else
                    runner.lane++;
            }
            else
            {

                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }

        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * rayRange));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * rayRange));

        if (Physics.Raycast(theRay, out RaycastHit hit, rayRange))
        {
            if (hit.collider.tag == "Obstacle")
            {
                SceneManager.LoadScene(0);
            }

        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}

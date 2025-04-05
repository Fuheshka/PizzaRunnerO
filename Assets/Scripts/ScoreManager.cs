using TMPro;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI Text

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreText; // ������ �� ��������� Text
    private float score;    // ������� ���������� �����
    private bool isRunning; // ���� ���������� ����

    [SerializeField]        // ��������� �������� �������� � ����������
    private float scorePerSecond = 10f; // ����� �� �������

    void Start()
    {
        // �������� ��������� Text � ���� �������, �� ������� ������
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0f;
        isRunning = true;

        // ������������� ��������� ��������
        UpdateScoreText();
    }

    void Update()
    {
        if (isRunning)
        {
            // ����������� ���� �� ������ �������
            score += scorePerSecond * Time.deltaTime;
            UpdateScoreText();
        }
    }

    // ����� ��� ���������� ������������� ������
    private void UpdateScoreText()
    {
        // ��������� �� ������ ����� � ��������� �����
        scoreText.text = "����: " + Mathf.FloorToInt(score).ToString();
    }

    // ����� ��� ��������� �������� (����� ������� ��� ���������)
    public void StopScoring()
    {
        isRunning = false;
    }

    // ����� ��� ��������� �������� �����
    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    // ����� ��� ������ �����
    public void ResetScore()
    {
        score = 0f;
        isRunning = true;
        UpdateScoreText();
    }
}

using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreText; // ������� ����
    [SerializeField] private TextMeshProUGUI highScoreText; // ����� ��� ������� �����
    private float score;    // ������� ���������� �����
    private int highScore;  // ������ ����
    private bool isRunning; // ���� ���������� ����

    [SerializeField] private float scorePerSecond = 10f; // ����� �� �������

    void Start()
    {
        // �������� ��������� TextMeshProUGUI � ���� �������, �� ������� ������
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0f;
        isRunning = true;

        // ��������� ������ ���� �� PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0); // 0 � �������� �� ���������
        UpdateHighScoreText();
        UpdateScoreText();
    }

    void Update()
    {
        if (isRunning)
        {
            // ����������� ���� �� ������ �������
            score += scorePerSecond * Time.deltaTime;
            UpdateScoreText();

            // ���������, �� ������ �� ������� ���� ������
            int currentScore = Mathf.FloorToInt(score);
            if (currentScore > highScore)
            {
                highScore = currentScore;
                UpdateHighScoreText();
                PlayerPrefs.SetInt("HighScore", highScore); // ��������� ����� ������
                PlayerPrefs.Save();
            }
        }
    }

    // ����� ��� ���������� ������������� ������ �������� �����
    private void UpdateScoreText()
    {
        scoreText.text = "����: " + Mathf.FloorToInt(score).ToString();
    }

    // ����� ��� ���������� ������������� ������ ������� �����
    private void UpdateHighScoreText()
    {

        highScoreText.text = "������: " + highScore.ToString();

    }

    // ����� ��� ��������� �������� (���������� ��� ���������)
    public void StopScoring()
    {
        isRunning = false;
    }

    // ����� ��� ��������� �������� �����
    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    // ����� ��� ������ �������� �����
    public void ResetScore()
    {
        score = 0f;
        isRunning = true;
        UpdateScoreText();
    }

    // ����� ��� ������ ������� ����� (�����������, ��� ������� ��� ��������)
    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
        UpdateHighScoreText();
    }
}
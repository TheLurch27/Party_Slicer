using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "" + currentScore;
    }
}

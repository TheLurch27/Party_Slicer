using UnityEngine;
using TMPro; // Falls du TextMeshPro benutzt

public class GameTimer : MonoBehaviour
{
    public float startTime = 120f; // 2 Minuten = 120 Sekunden
    private float currentTime;
    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            // Hier kannst du später Game Over auslösen
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}

using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 120f; // Всього часу в секундах (2 хвилини)
    private float currentTime;

    public TextMeshProUGUI timerText;
    private string initialTimerText;

    private bool timerActive = true;

    void Start()
    {
        currentTime = totalTime;
        initialTimerText = timerText.text; // Зберігаємо початковий текст
        UpdateTimerText();
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                timerActive = false;
                // Тут можна додати дії, які виконуються, коли час вийшов
                Debug.Log("Час вийшов!");
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0} {1:00}:{2:00}", initialTimerText.Split(' ')[0], minutes, seconds);
    }
}

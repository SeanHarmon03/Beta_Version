using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    public GameObject GameOverPanel;
    private float timeLeft = 60f;
    private bool timerGoing = true;

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
        if (timeLeft > 0)
            {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay(timeLeft);
            
        }
        else 
        {
            timeLeft = 0;
            timerGoing = false;
            TriggerGameOver();
        }
        }
    }
    void UpdateTimerDisplay(float time)
{
    int minutes = Mathf.FloorToInt(time / 60);
    int seconds = Mathf.FloorToInt(time % 60);
    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
}

void TriggerGameOver()
{
    GameOverPanel.SetActive(true);
    Time.timeScale = 0;


}
}



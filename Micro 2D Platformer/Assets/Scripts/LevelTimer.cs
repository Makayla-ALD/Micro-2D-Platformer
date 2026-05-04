using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] float remainTime; 

    void Update()
    {
       if(remainTime > 0) // Check if there is still time remaining
        {
            remainTime -= Time.deltaTime;
        }
       else if (remainTime <= 0) //If remaining itme is less than 0, set text number to 0
        {
            remainTime = 0;
            
        }

        remainTime -= Time.deltaTime; // Decrease the remaining time by the time that has passed since the last frame
        int minutes = Mathf.FloorToInt(remainTime / 60);
        int seconds = Mathf.FloorToInt(remainTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}

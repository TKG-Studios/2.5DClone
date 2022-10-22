using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsBox : MonoBehaviour
{
    public MetricsTimer timer;
    public bool isTimerRunning;
 

   


    private void Update()
    {
        if (isTimerRunning)
        {
            timer.timer += Time.deltaTime;
            timer.speedText.text = "Move Speed: " + timer.timer.ToString("F2");
        }
        
      if (!isTimerRunning)
        {
            
            timer.speedText.text = "Move Speed: " + timer.timer.ToString("F2");
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTimerRunning)
        {
            isTimerRunning = true;
         
        }

        else if (collision.CompareTag("Player") && isTimerRunning)
        {
            isTimerRunning = false;
        }

    }
}

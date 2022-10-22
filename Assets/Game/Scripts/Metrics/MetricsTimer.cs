using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MetricsTimer : MonoBehaviour
{
    public TextMeshPro speedText;
    public float timer;
    public bool isTimerRunning;


    private void Start()
    {
        isTimerRunning = false;
        timer = 0;
    }




}

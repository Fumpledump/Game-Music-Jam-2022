using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TextMeshProUGUI timerCounter;

    public TimeSpan timePlaying;
    public bool timerGoing;

    public float elapsedTime;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        timerCounter.text = "00:00.00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timerCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public void ShowTimer(bool activate)
    {
        timerCounter.gameObject.SetActive(activate);
    }
}

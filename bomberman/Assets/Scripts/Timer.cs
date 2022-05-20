using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int firstLeft = 0;
    public int secondLeft = 15;
    public bool takingAway = false;
    private IEnumerator coroutine;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "0" + firstLeft + ":" + secondLeft;
    }

    void Update()
    {
        if (takingAway == false)
        {
            if (secondLeft > 0)
            {
                coroutine = TimerTake();
                StartCoroutine(coroutine);
            }
            if (secondLeft == 0 && firstLeft > 0)
            {

                secondLeft = 60;
                firstLeft -= 1;
                coroutine = TimerTake();
                StartCoroutine(coroutine);
            }
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        if (secondLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "0" + firstLeft + ":0" + secondLeft;
        }
        else
        {
            if (firstLeft == 0 && secondLeft == 10)
            {
                FindObjectOfType<AudioManager>().Play("countdown");
            }
            textDisplay.GetComponent<Text>().text = "0" + firstLeft + ":" + secondLeft;
        }
        takingAway = false;
    }

    public void stopTimer()
    {
        StopCoroutine(coroutine);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondLeft = 120;
    public bool takingAway = false;
    private IEnumerator coroutine;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondLeft;
    }

    void Update()
    {
        if (takingAway == false && secondLeft > 0)
        {
            coroutine = TimerTake();
            StartCoroutine(coroutine);
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        if (secondLeft < 10){
            textDisplay.GetComponent<Text>().text = "00:0" + secondLeft;

        }
        else{
            if(secondLeft == 10){
                FindObjectOfType<AudioManager>().Play("countdown");
            }
            textDisplay.GetComponent<Text>().text = "00:" + secondLeft;
        }
        takingAway = false;
    }

    public void stopTimer()
    {
        StopCoroutine(coroutine);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";
        SceneManager.LoadScene("FinalMenu");
    }

    public void RestartButtton()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitButtton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text winner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver(string name)
    {
        FindObjectOfType<AudioManager>().Play("endgame");
        if (name == "Player 1")
            winner.text = "Player 2";
        else
            winner.text = "Player 1";
        gameOverScreen.SetActive(true);
    }
}

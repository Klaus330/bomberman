using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerReactions : MonoBehaviour
{
    public int boost = 2;
    public bool canMoveBombs = false;
    public float canMoveCountdown = 5f;
    public float hasBoostCountDown = 5f;
    public float hasMoreBombsCountDown = 50f;
    public bool hasMoreBombs = false;
    public bool isPlacingBombsRandom = false;
    public float isPlacingBombsRandomCountDown = 10f;
    public bool isInvincible = false;
    public float isInvincibleCountDown = 5f;
    int maxPlatform = 10;
    public float timeStart = 0f;

    public async void die()
    {
        // TO DO: dying logic
        Debug.Log("DEAD PLAYER");
        FindObjectOfType<AudioManager>().Play("deathVoice");
        FindObjectOfType<GameManager>().GameOver(gameObject.name);
        FindObjectOfType<PowerUpRandomSpawner>().buildSpirala = false;
        FindObjectOfType<Timer>().stopTimer();
        FindObjectOfType<AudioManager>().Stop("countdown");
        FindObjectOfType<PowerUpRandomSpawner>().stopSpirala();
        Destroy(gameObject);
    }

    public bool itCanMoveBombs()
    {
        return canMoveBombs;
    }

    void FixedUpdate()
    {
        if(canMoveBombs)
        {
            if(canMoveCountdown <= 0)
            {
                canMoveBombs = false;
                canMoveCountdown = 20f;
            }
            canMoveCountdown -= Time.fixedDeltaTime;
        }

        if(boost > 2)
        {
            if(hasBoostCountDown <= 0){
                boost = 2;
                hasBoostCountDown = 20f;
            }
            hasBoostCountDown -= Time.fixedDeltaTime;
        }

        if(hasMoreBombs)
        {
            if(hasMoreBombsCountDown <= 0){
                gameObject.GetComponent<PlayerBombSpawner>().maxNrOfBombs = 1;
                gameObject.GetComponent<PlayerBombSpawner>().numberOfBombs = 1;
                hasMoreBombs = false;
                hasMoreBombsCountDown = 50f;
            }

            hasMoreBombsCountDown -= Time.fixedDeltaTime;
        }   


        if(isPlacingBombsRandom)
        {
            if(isPlacingBombsRandomCountDown <= 0)
            {
                isPlacingBombsRandomCountDown = 10f;
                isPlacingBombsRandom = false;
            }

            float chance = Random.Range(0f, 1f);

            if(chance < 0.025)
            {
               GetComponent<PlayerBombSpawner>().placeBomb();
            }

            isPlacingBombsRandomCountDown -= Time.fixedDeltaTime;
        }

        if(isInvincible)
        {
            if(isInvincibleCountDown <= 0)
            {
                isInvincible = false;
                isInvincibleCountDown = 5f;
            }

            isInvincibleCountDown -= Time.fixedDeltaTime;
        }
    }
}

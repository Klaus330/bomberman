using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// use textmesh pro
using TMPro;

public class PlayerStatusManager : MonoBehaviour
{

    public GameObject fisrtPlayerStatus;
    public GameObject secondPlayerStatus;
    GameObject[] players;

    const string MORE_BOMBS_TAG = "MoreBombs";
    const string MOVE_BOMBS_TAG = "MoveBombs";
    const string BOMBS_NUMBER_TAG = "Bombs";
    const string FLAMES_NUMBER_TAG = "Flame";
    const string INVINCIBLE_TAG = "Invincible";
    const string SLOWDOWN_TAG = "SlowDown";
    const string RANDOM_BOMBS_TAG = "RandomBombs";
    // const string LESS_EFFECT_TAG = "LessEffect";

    // Update is called once per frame
    void FixedUpdate()
    {
        FetchPlayers();
        updateStatusForPlayer(players[0]);
        updateStatusForPlayer(players[1]);
    }

    void FetchPlayers()
    {
        if(players != null && players.Length > 0)
        {
            return;
        }

        players = GameObject.FindGameObjectsWithTag("Player");
    }


    void updateStatusForPlayer(GameObject player)
    {
        GameObject status;

        if (player.name == "Player 1") {
            status = fisrtPlayerStatus;
        }else {
            status = secondPlayerStatus;
        }

        TextMeshProUGUI bombsText = Helper.FindComponentInChildWithTag<TextMeshProUGUI>(status.GetComponent<RectTransform>(), BOMBS_NUMBER_TAG);
        bombsText.text = player.GetComponent<PlayerBombSpawner>().numberOfBombs.ToString();

        TextMeshProUGUI flameText = Helper.FindComponentInChildWithTag<TextMeshProUGUI>(status.GetComponent<RectTransform>(), FLAMES_NUMBER_TAG);
        flameText.text = player.GetComponent<PlayerReactions>().boost.ToString();

        if(! player.GetComponent<PlayerReactions>().canMoveBombs){
            Image moveBomb = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), MOVE_BOMBS_TAG);
            changeOpacity(moveBomb);
        }

        if(! player.GetComponent<PlayerReactions>().hasMoreBombs){
            Image moreBombs = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), MORE_BOMBS_TAG);
            changeOpacity(moreBombs);
        }

        if(! player.GetComponent<PlayerReactions>().isInvincible){
            Image invincible = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), INVINCIBLE_TAG);
            changeOpacity(invincible);
        }

        if(! player.GetComponent<PlayerMovement>().isSpeedAffected){
            Image slowDown = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(),SLOWDOWN_TAG);
            changeOpacity(slowDown);
        }

        if(! player.GetComponent<PlayerReactions>().isPlacingBombsRandom){
            Image randomBombs = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), RANDOM_BOMBS_TAG);
            changeOpacity(randomBombs);
        }

        // if(player.GetComponent<PlayerReactions>().smaller){
        //     Image lessEffect = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), LESS_EFFECT_TAG);
        //     changeOpacity(lessEffect);
        // }
    }

    void changeOpacity(Image img, float opacity = 0.5f)
    {
        var tempColor = img.color;
        tempColor.a = opacity;
        img.color = tempColor;
    }


    public void activatePowerUpForUser(GameObject player, string powerUpTag)
    {
        // Debug.Log("activatePowerUpForUser "+player.name + " " + powerUpTag);
        GameObject status;

        if (player.name == "Player 1") {
            status = fisrtPlayerStatus;
        }else {
            status = secondPlayerStatus;
        }

        Image powerup = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), powerUpTag);
        Debug.Log("powerup " + powerup);
        changeOpacity(powerup, 1f);
    }

    public void deactivatePowerUpForUser(GameObject player, string powerUpTag)
    {
        GameObject status;

        if (player.name == "Player 1") {
            status = fisrtPlayerStatus;
        }else {
            status = secondPlayerStatus;
        }

        Image powerup = Helper.FindComponentInChildWithTag<Image>(status.GetComponent<RectTransform>(), powerUpTag);
        changeOpacity(powerup);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject[] spawnLocations;

    void Start()
    {
        PlayerInput p1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
        PlayerInput p2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
        p1.name = "Player 1";
        p2.name = "Player 2";
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnLocations[playerInput.playerIndex].transform.position;
    }

}

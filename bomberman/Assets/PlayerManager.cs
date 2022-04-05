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
        PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
        PlayerInput.Instantiate(playerPrefab, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnLocations[playerInput.playerIndex].transform.position;
    }

}

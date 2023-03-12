using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class WaitReadyUI : MonoBehaviour
{
    [SerializeField] private Button readyButton;
    [SerializeField] private Button mainMenu;
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI lobbyCodeText;
    [SerializeField] private Image playerReady1;
    [SerializeField] private Image playerReady2;
    private void Awake()
    {
        readyButton.onClick.AddListener(() =>
        {
            ReadyScript.Instance.SetPlayerReady();
            readyButton.gameObject.SetActive(false);
        });
        mainMenu.onClick.AddListener(() =>
        {
            GameLobbyScript.Instance.LeaveLobby();
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.DenchikMainMenu);
        });
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectCallback;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallback;
    }
    private void OnClientDisconnectCallback(ulong obj)
    {
        playerReady2.color = Color.clear;
    }

    private void OnClientConnectCallback(ulong obj)
    {
        playerReady2.color = Color.green;
    }
    private void Start()
    {
        Lobby lobby = GameLobbyScript.Instance.GetLobby();

        lobbyNameText.text = "Lobby Name: " + lobby.Name;
        lobbyCodeText.text = "Lobby Code: " + lobby.LobbyCode;
    }

    private void OnDestroy()
    {
        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnectCallback;
        NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnectCallback;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button startHostBtn;
    [SerializeField] private Button startClientBtn;
    [SerializeField] private LobbyCreateUI lobbyCreateUI;
    [SerializeField] private Button joinCodeBtn;
    [SerializeField] private TMP_InputField joinCodeField;
    [SerializeField] private Transform lobbyContainer;
    [SerializeField] private Transform lobbyTemplate;

    private void Awake()
    {
        startHostBtn.onClick.AddListener(() =>
        {
            lobbyCreateUI.Show();
        });
        mainMenuBtn.onClick.AddListener(() =>
        {
            GameLobbyScript.Instance.LeaveLobby();
            Loader.Load(Loader.Scene.DenchikMainMenu);
        });
        startClientBtn.onClick.AddListener(() =>
        {
            GameLobbyScript.Instance.QuickJoin();
        });
        joinCodeBtn.onClick.AddListener(() =>
        {
            GameLobbyScript.Instance.JoinWithID(joinCodeField.text);
        });
        
        lobbyTemplate.gameObject.SetActive(false);
        
    }
    private void Start()
    {
        GameLobbyScript.Instance.OnLobbyListChanged += OnLobbyListChanged;
        UpdateLobbyList(new List<Lobby>());
    }

    private void OnLobbyListChanged(object sender, GameLobbyScript.OnLobbyListChangedEventArgs e)
    {
        UpdateLobbyList(e.lobbies);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList)
    {
        foreach (Transform child in lobbyContainer)
        {
            if (child == lobbyTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Lobby lobby in lobbyList)
        {
            Transform lobbyTransform = Instantiate(lobbyTemplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }
}

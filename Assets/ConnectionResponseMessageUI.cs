using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionResponseMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }
    private void Start()
    {
        GameMultiplayer.Instance.OnFailedToJoin += OnFailedToJoinGame;
        GameLobbyScript.Instance.OnCreateLobbyStarted += OnCreateLobbyStarted;
        GameLobbyScript.Instance.OnCreateLobbyFailed += OnCreateLobbyFailed;
        GameLobbyScript.Instance.OnJoinFailed += OnJoinFailed;
        GameLobbyScript.Instance.OnJoinStarted += OnJoinStarted;
        GameLobbyScript.Instance.OnQuickJoinFailed += OnQuickJoinFailed;
        GameLobbyScript.Instance.EmptyCode += EmptyCode;
        Hide();
    }

    private void EmptyCode(object sender, EventArgs e)
    {
        ShowMessage("Empty join code");
    }

    private void OnQuickJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Players not found to quick join :((");
    }

    private void OnJoinStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining to lobby...");
    }

    private void OnJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to join lobby :(");
    }

    private void OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to create lobby :(");
    }

    private void OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating lobby...");
    }

    private void OnFailedToJoinGame(object sender, EventArgs e)
    {
        if (NetworkManager.Singleton.DisconnectReason == "")
        {
            ShowMessage("Failed to connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void ShowMessage(string message)
    {
        Show();
        messageText.text = message;
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameMultiplayer.Instance.OnFailedToJoin -= OnFailedToJoinGame;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button createButtonPublic;
    [SerializeField] private Button createButtonPrivate;
    [SerializeField] private TMP_InputField lobbyNameInput ;

    private void Awake()
    {
        createButtonPublic.onClick.AddListener(() =>
        {
            if (lobbyNameInput.text == "")
                lobbyNameInput.text = "Lobby " + Random.Range(1, 1000000);
            GameLobbyScript.Instance.CreateLobby(lobbyNameInput.text, false);
        });
        createButtonPrivate.onClick.AddListener(() =>
        {
            if (lobbyNameInput.text == "")
                lobbyNameInput.text = "Lobby " + Random.Range(1, 1000000);
            GameLobbyScript.Instance.CreateLobby(lobbyNameInput.text, true);
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

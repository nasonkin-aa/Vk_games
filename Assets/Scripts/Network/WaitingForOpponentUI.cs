using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class WaitingForOpponentUI : MonoBehaviour
{
    [SerializeField] private Button mainMenu;

    private void Awake()
    {
        mainMenu.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.DenchikMainMenu);
        });
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisonnectCallback;
        Hide();
    }

    private void OnClientDisonnectCallback(ulong clientId)
    {
        Show();
        Time.timeScale = 0f;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

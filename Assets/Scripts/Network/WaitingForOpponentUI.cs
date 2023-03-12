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
        Time.timeScale = 0f;
        Show();
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

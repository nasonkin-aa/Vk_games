using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class HostDisconnect : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += ClientDisconnectCallback;
    }

    private void ClientDisconnectCallback(ulong clientId)
    {
        if (clientId == NetworkManager.ServerClientId)
        {
            SceneManager.LoadScene(0);
        }
    }
}

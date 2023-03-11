using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ReadyScript : NetworkBehaviour
{
    public static ReadyScript Instance { get; private set; }
    
    private Dictionary<ulong, bool> playerReadyDictionary;

    private void Awake()
    {
        Instance = this;
        playerReadyDictionary = new Dictionary<ulong, bool>();
    }

    public void SetPlayerReady()
    {
        SetPlayerReadyServerRpc();
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void SetPlayerReadyServerRpc(ServerRpcParams serverRpcParams = default)
    {
        playerReadyDictionary[serverRpcParams.Receive.SenderClientId] = true;

        bool allClientsReady = true;
        foreach (var clientsId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (!playerReadyDictionary.ContainsKey(clientsId) || !playerReadyDictionary[clientsId])
            {
                allClientsReady = false;
                break;
            }
        }
        Debug.Log(serverRpcParams.Receive.SenderClientId);
        Debug.Log(allClientsReady);
        if (allClientsReady && NetworkManager.Singleton.ConnectedClientsIds.Count != 1)
        {
            Loader.LoadNetwork(Loader.Scene.DenchikGame);
        }
    }
}

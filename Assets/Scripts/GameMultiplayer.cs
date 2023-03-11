using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMultiplayer : NetworkBehaviour
{
    public static GameMultiplayer Instance { get; private set; }

    public EventHandler OnTryingToJoin;
    public EventHandler OnFailedToJoin;
    private void Awake()
    {
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void ConnectionApprovalCallback(NetworkManager.ConnectionApprovalRequest connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse connectionApprovalResponse)
    {
        if (SceneManager.GetActiveScene().name != Loader.Scene.DenchikReady.ToString())
        {
            connectionApprovalResponse.Approved = false;
            connectionApprovalResponse.Reason = "game had already start";
            return;
        }

        if (NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
        {
            connectionApprovalResponse.Approved = false;
            connectionApprovalResponse.Reason = "game is full";
            return;
        }
        connectionApprovalResponse.Approved = true;
    }

    public void StartClient()
    {
        OnTryingToJoin?.Invoke(this, EventArgs.Empty);
        
        NetworkManager.Singleton.ConnectionApprovalCallback += ConnectionApprovalCallback;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallBack;
        NetworkManager.Singleton.StartClient();
    }

    private void OnClientDisconnectCallBack(ulong clientId)
    {
        OnFailedToJoin?.Invoke(this,EventArgs.Empty);
    }
}

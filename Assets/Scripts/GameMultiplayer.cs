using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameMultiplayer : NetworkBehaviour
{
    public static GameMultiplayer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    public void StartHost()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ConnectionApprovalCallback;
        NetworkManager.Singleton.StartHost();
    }

    private void ConnectionApprovalCallback(NetworkManager.ConnectionApprovalRequest connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse connectionApprovalResponse)
    {
        if (GameManager.Instance.IsWaitingToStart())
        {
            connectionApprovalResponse.Approved = true;
            connectionApprovalResponse.CreatePlayerObject = true;
        }
        else
        {
            connectionApprovalResponse.Approved = false;
        }
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
    
}

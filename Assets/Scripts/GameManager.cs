using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnLocalPlayerReadyChanged;
    private Dictionary<ulong, bool> playerReadyDictionary;

    private enum State
    {
        GamePlaying,
        WaitingToStart,
        GameOver
    }

    [SerializeField] private Transform playerPrefab;

    private NetworkVariable<State> state = new NetworkVariable<State>(State.WaitingToStart);

    public void OnInteractAction()
    {
        if (state.Value == State.WaitingToStart)
        {
            SetPlayerReadyServerRpc();
            OnLocalPlayerReadyChanged?.Invoke(this, EventArgs.Empty);
        }
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
            state.Value = State.GamePlaying;
        }
    }

    public override void OnNetworkSpawn()
    {
        state.OnValueChanged += StateOnValueChanged;

        if (IsServer)
        {
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += OnLoadEventCompleted;
        }
    }

    private void OnLoadEventCompleted(string scenename, LoadSceneMode loadscenemode, List<ulong> clientscompleted, List<ulong> clientstimedout)
    {
        foreach (var clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            Transform playerTransform = Instantiate(playerPrefab);
            playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId, true);
        }
    }

    private void StateOnValueChanged(State previousvalue, State newvalue)
    {
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Awake()
    {
        Instance = this;
        state.Value = State.WaitingToStart;
        playerReadyDictionary = new Dictionary<ulong, bool>();
    }

    private void Update()
    {
        if (!IsServer)
        {
            return;
        }
        switch (state.Value)
        {
            case State.WaitingToStart:
                break;
            case State.GamePlaying:
                // TODO: Gameover reason 
                break;
            case State.GameOver:
                break;
        }
    }

    public bool IsGamePlaying()
    {
        return state.Value == State.GamePlaying;
    }

    public bool IsWaitingToStart()
    {
        return state.Value == State.WaitingToStart;
    }
}

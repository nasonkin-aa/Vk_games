using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
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
            GameLobbyScript.Instance.JoinWithCode(joinCodeField.text);
        });
    }

}

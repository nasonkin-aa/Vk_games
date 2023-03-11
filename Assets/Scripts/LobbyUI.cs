using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button startHostBtn;
    [SerializeField] private Button startClientBtn;

    private void Awake()
    {
        startHostBtn.onClick.AddListener(() =>
        {
            GameMultiplayer.Instance.StartHost();
            Loader.LoadNetwork(Loader.Scene.DenchikReady);
        });
        startClientBtn.onClick.AddListener(() =>
        {
            GameMultiplayer.Instance.StartClient();
        });
    }

}

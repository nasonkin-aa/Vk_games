using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{
    private void Start()
    {
        GameMultiplayer.Instance.OnTryingToJoin += OnTryingToJoinGame;
        GameMultiplayer.Instance.OnFailedToJoin += OnFailedToJoinGame;
        Hide();
    }

    private void OnFailedToJoinGame(object sender, EventArgs e)
    {
        Hide();
    }

    private void OnTryingToJoinGame(object sender, EventArgs e)
    {
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
    
    private void OnDestroy()
    {
        GameMultiplayer.Instance.OnTryingToJoin -= OnTryingToJoinGame;
        GameMultiplayer.Instance.OnFailedToJoin -= OnFailedToJoinGame;
    }
}

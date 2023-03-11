using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingForOpponentUI : MonoBehaviour
{
    [SerializeField] private Button readyButton;

    private void Awake()
    {
        readyButton.onClick.AddListener(() =>
        {
            GameManager.Instance.OnInteractAction();
            readyButton.gameObject.SetActive(false);
        });
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += OnStateChanged;
        Show();
    }

    private void OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            Hide();
        }
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

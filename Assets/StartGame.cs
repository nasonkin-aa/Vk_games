using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button Start;

    private void Awake()
    {
        Start.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.AndreyTest1);
        });
    }
}

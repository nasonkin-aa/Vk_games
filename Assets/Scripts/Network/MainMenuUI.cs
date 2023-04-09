using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button MainMenu;

    private void Awake()
    {
        MainMenu.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.DenchikMainMenu);
        });
    }
}

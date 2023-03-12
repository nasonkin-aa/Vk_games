using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Resurses : MonoBehaviour
{
    public TMP_Text TextMoney;
    public static TMP_Text tex;
    private static int _money = 1000;
    public static int Money { 
        get => _money;
        set { 
            _money = value;
            tex.text = value.ToString(); 

        } 
    } 
    public void Start()
    {
        tex = TextMoney;
        TextMoney.text = Money.ToString();
    }
}

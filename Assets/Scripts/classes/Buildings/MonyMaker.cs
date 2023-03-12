using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonyMaker : Building
{
    private float _nextMoneyTime = 5;
    private float _nextMoneyAmount = 5;
    public void AddMoney()
    {
        Resurses.Money += 5;
    }
    public void FixedUpdate()
    {
        if (!IsDropedBuilding)
            return;
        _nextMoneyTime -= Time.deltaTime;
        if (_nextMoneyTime < 0)
        {
            AddMoney();
            _nextMoneyTime = _nextMoneyAmount;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : DamageBuilding
{
    public void Awake()
    {
        base.Awake();
        Cost = 70;
    }
}
